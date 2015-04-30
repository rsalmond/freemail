[![Build Status](https://travis-ci.org/willwhite/freemail.svg?branch=master)](https://travis-ci.org/willwhite/freemail)

# freemail

A database of free and [disposable](http://en.wikipedia.org/wiki/Disposable_email_address)
email domains and a handy javascript module for querying it.

Use the javascript module or access the files in the `./data` directory and parse
with your language of choice.

In an effort to create the most up-to-date list of domains, the database can be
synchronized with various lists from around the web. You can also add new
domains directly by opening a pull request.

## Database

There are three key data files in this project:

- [free.txt](https://github.com/willwhite/freemail/blob/master/data/free.txt) contains a list of domains that are known to provide free email service
- [disposable.txt](https://github.com/willwhite/freemail/blob/master/data/disposable.txt) contains a list of domains that are known to provide disposable email service
- [blacklist.txt](https://github.com/willwhite/freemail/blob/master/data/blacklist.txt) contains a list of domains that this project will refuse to add to either list

Domains may only be a member of one list.

## Javascript

### Install

```
npm install --save freemail
```

```javascript
freemail.isFree('smith@gmail.com');
> true
freemail.isFree('jack@mailinater.com');
> true
freemail.isDisposable('smith@gmail.com');
> false
freemail.isDisposable('jack@mailinater.com');
> true

```
