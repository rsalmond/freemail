#!/usr/bin/env bash

set -e

tmp=$(touch tempblacklist)
cat ./data/blacklist.txt \
    | sed '/./,$!d' \
    | sed -e 's/^ *//' -e 's/ *$//' \
    | awk '{print tolower($0)}' \
    | sort \
    | uniq > '$tmp'
mv '$tmp' ./data/blacklist.txt

tmp=$(touch tempfree)
cat ./data/free.txt \
    | sed '/./,$!d' \
    | sed -e 's/^ *//' -e 's/ *$//' \
    | awk '{print tolower($0)}' \
    | sort \
    | uniq \
    | comm -23 - ./data/blacklist.txt > '$tmp'
mv '$tmp' ./data/free.txt

tmp=$(touch tempdisposable)
cat ./data/disposable.txt \
    | sed '/./,$!d' \
    | sed -e 's/^ *//' -e 's/ *$//' \
    | awk '{print tolower($0)}' \
    | sort \
    | uniq \
    | comm -23 - ./data/blacklist.txt \
    | comm -23 - ./data/free.txt > '$tmp'
mv '$tmp' ./data/disposable.txt

sources=$(cat ./data/sources.txt)
new=$(touch tempnew)
for source in $sources; do
    echo "$(curl --silent $source)" >> $new
done;

tmp=$(touch tempall)
cat $new \
    | sed '/./,$!d' \
    | sed -e 's/^ *//' -e 's/ *$//' \
    | awk '{print tolower($0)}' \
    | sort \
    | uniq \
    | comm -23 - ./data/blacklist.txt \
    | comm -23 - ./data/free.txt \
    | comm -23 - ./data/disposable.txt > '$tmp'

confirmed=$(touch tempconfirmed)
for domain in $(cat $tmp); do
    result=`dig +short mx $domain`
    if [ -n "$result" ]; then
        echo $domain >> $confirmed
    fi
done

tmp=$(touch tempfreemail)
cat $confirmed ./data/free.txt \
    | sort \
    | uniq > '$tmp'
mv '$tmp' ./data/free.txt

echo 'Complete!'
read
