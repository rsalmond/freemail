[![Build Status](https://travis-ci.org/willwhite/freemail.svg?branch=master)](https://travis-ci.org/willwhite/freemail)

# freemail

A database of free and [disposable](http://en.wikipedia.org/wiki/Disposable_email_address)
email domains with a handy javascript module and .net library for querying it.

Use the javascript module for client side queries, or the .net library for server side queries.

In an effort to create the most up-to-date list of domains, the database can be
synchronized with various lists from around the web. You can also add new
domains directly by opening a pull request.

## Database

There are three key data files in this project:

- [free.txt](https://github.com/willwhite/freemail/blob/master/data/free.txt) contains a list of domains that are known to provide free email service
- [disposable.txt](https://github.com/willwhite/freemail/blob/master/data/disposable.txt) contains a list of domains that are known to provide disposable email service
- [blacklist.txt](https://github.com/willwhite/freemail/blob/master/data/blacklist.txt) contains a list of domains that this project will refuse to add to either list

Domains may only be a member of one list.

## Updating the database

Run `./update` to pull in the latest domains from the sources listed in
`sources.txt`. All new domains will be placed in `free.txt` by default.
If any domains provide disposable email service, they may be moved to
`disposable.txt`.

## Install
There are two available nuget packages:
- PM> Install-Package freemail.js (client side javascript implementation)
- PM> Install-Package freemail.net (server side .net implementation)

## Javascript Example

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

## CSharp Example

```
Freemail.Queries.IsFree('smith@gmail.com');
> true
Freemail.Queries.IsFree('jack@mailinater.com');
> true
Freemail.Queries.IsDisposable('smith@gmail.com');
> false
Freemail.Queries.IsDisposable('jack@mailinater.com');
> true

```
