from __future__ import unicode_literals
import codecs
import sys
import json
import os
import xml.etree.ElementTree as ET
import re
import requests
from requests_oauthlib.oauth1_auth import OAuth1
import time
import datetime
import math
import indicoio

sys.path.insert(0, os.path.abspath('..'))

############################################### BEGIN OF CRAWLER ###############################################

REQUEST_TOKEN_URL = "https://api.twitter.com/oauth/request_token"
AUTHORIZE_URL = "https://api.twitter.com/oauth/authorize"
ACCESS_TOKEN_URL = "https://api.twitter.com/oauth/access_token"

CONSUMER_KEY = "zfbpBDWaCP928z48JybTnw"
CONSUMER_SECRET = "iWZbH0lRqabem9soA0nR76eMe4cwVOfUSm8DcjP2uiY"

OAUTH_TOKEN = "72264591-NROFktZG6uXQoCXELYDTLdWNVCaMlsAizJdJubOau"
OAUTH_TOKEN_SECRET = "SdslnFRiDai0vFYQoIPm8GQIzpF070CnMvdozTZdcMkho"

def get_oauth():
    oauth = OAuth1(CONSUMER_KEY,client_secret=CONSUMER_SECRET,resource_owner_key=OAUTH_TOKEN,resource_owner_secret=OAUTH_TOKEN_SECRET)
    return oauth

###############################################
def serialize_json_list(json_list, tagname, tabs=1):
    # opening tag with possible attributes
    output = "  "*tabs + "<" + tagname + ">\n"
    
    # child nodes
    key = 'item'
    for value in json_list:
        if isinstance(value, list):
            output += serialize_json_list(value, key, tabs=tabs+1)
        elif isinstance(value, dict):
            output += serialize_json_dict(value, key, tabs=tabs+1)
        else:
            output += serialize_json_attr(value, key, tabs=tabs+1)
    
    # closing tag
    output += "  "*tabs + "</" + tagname + ">\n"
    return output

def serialize_json_dict(json_dict, tagname, attributes={}, tabs=1):
    # opening tag with possible attributes
    output = "  "*tabs + "<" + tagname 
    output += " " if len(attributes) > 0 else ""
    output += " ".join(key + '="' + str(value) + '"' for (key, value) in attributes.items()) 
    output += ">\n"
    
    # child nodes
    for key, value in json_dict.items():
        
        if isinstance(value, list):
            output += serialize_json_list(value, key, tabs=tabs+1)
        elif isinstance(value, dict):
            output += serialize_json_dict(value, key, tabs=tabs+1)
        else:
            output += serialize_json_attr(value, key, tabs=tabs+1)
    
    # closing tag
    output += "  "*tabs + "</" + tagname + ">\n"
    return output

def serialize_json_attr(json_attr, tagname, tabs=1):
    output = "  "*tabs + "<" + tagname + ">" + str(json_attr) + "</" + tagname + ">\n" 
    return output

def get_xml_from_json(json_data):
    output = "<tweets>\n"
    for ix, tweet in enumerate(json_data):
        output += serialize_json_dict(tweet, "tweet", {"number": ix+1})
    output += "</tweets>\n"
    return output
###############################################

if __name__ == "__main__":
    oauth = get_oauth()    
    url = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=moerafaat&count=4"        
    r = requests.get(url, auth=oauth)
    result = r.json()
    
    with codecs.open("res.json",'w','utf-8') as f:
        f.write(json.dumps(result))
        xml=get_xml_from_json(result)
    with codecs.open("result.xml",'w','utf-8') as f:        
        f.write(xml)

    filtered=codecs.open("fresult.xml",'w','utf8') # new file to write xml without letter '&'.
    
    f=codecs.open("result.xml", 'r', 'utf-8')
    r=f.readlines()
    
    for line in r:
        l= [item for item in re.split('&',line) if item] # to remove the character '&' as it raises an error when parsing xml file.
        for word in l:
            filtered.write(word +" ")
        
    filtered.close()
    fi=codecs.open("fresult.xml",'r')
    file1 = codecs.open("tweets.txt",'w','utf8')
    tree = ET.parse(fi)
    root = tree.getroot()
    
    for tweet in root.findall('tweet'):
        data=tweet.find('text').text
        f2 = data.split()
        for line in f2:
            cleanedline=line.strip() # to remove empty lines inside tweets text.
            if cleanedline:
                file1.write(cleanedline)
                file1.write(" ")
        file1.write("\n")        
        data= tweet.find('created_at').text
        file1.write(data)
        file1.write("\n")
 
    f.close()
    fi.close()
    file1.close()
    os.remove("res.json")
    os.remove("fresult.xml")
    os.remove("result.xml")
    
    ############################################### END OF CRAWLER ###############################################
    
    ############################################### BEGIN OF SENTIMENTS ###############################################
    
    indicoio.config.api_key = "8c342644b232b62792927678523256fc"
    
    # Filter posts and emotion analysis.
    tweets_file = open("tweets.txt", 'r')
    tweets_lines = tweets_file.readlines()
    for i in range(0, len(tweets_lines)):
        tweets_lines[i]=tweets_lines[i].strip() # removes the \n from entries.
    posts = []
    current_time = datetime.datetime.now()
    delta_time = []
    for i in range(0, len(tweets_lines), 2):
        time_stamp = time.strftime('%Y-%m-%d %H:%M:%S', time.strptime(tweets_lines[i+1],'%a %b %d %H:%M:%S +0000 %Y'))
        date_time = datetime.datetime.strptime(time_stamp, "%Y-%m-%d %H:%M:%S") + datetime.timedelta(hours = 2)
        difference = (current_time - date_time).total_seconds()
        if(difference <= 3600): # Get posts within an hour.
            posts.append(tweets_lines[i]) # creating tweets array.
            delta_time.append(difference / 3600)
    #print(posts)
    
    # Emotion analysis.
    emotion_file = open("text_emotion.txt", 'w')
    size = len(posts)
    if(size > 0):
        weight_latest = 0.45
        weight_entropy = 0.55
        normalized_time = delta_time
        normalized_entropy = []
        #print("Normalized Time", normalized_time)
        
        emotions = indicoio.emotion(posts)
        max_entropy = -0.2 * math.log(0.2, 2) * 5
        for i in range(0, size):
            entropy = 0
            #print("*****")
            #print("Probabilities:")
            for emotion, prob in emotions[i].items():
                entropy = entropy - (prob * math.log(prob, 2))
                #print(emotion, prob)
            entropy = entropy / max_entropy
            normalized_entropy.append(entropy)
            #print("#####")
            #print("Entropy", entropy)
            #print("*****")
        
        rank_final = []
        min_rank = 1000
        min_post = 1000
        for i in range(0, size):
            weight = weight_latest * normalized_time[i] + weight_entropy * normalized_entropy[i]
            rank_final.append((weight, i))
            if(weight < min_rank):
                min_rank = weight
                min_post = i
        #print("Rank Final", rank_final)
        #print("Winner Post", min_post)
        json.dump(emotions[min_post], emotion_file)
        
    ############################################### END OF SENTIMENTS ###############################################