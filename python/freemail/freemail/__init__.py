# -*- coding: utf-8 -*-

"""
A python implementation of Freemail, the
database of free and disposable email domains.
"""

__title__ = 'freemail'
__version__ = '0.0.1'
__author__ = 'rob salmond'
__license__ = 'MIT'

import os

class Freemail(object):
    free_file = 'free.txt'
    disp_file = 'disposable.txt'
    data_dir = 'data'

    free_domains = None
    disp_domains = None

    def __init__(self):
        ff_path = os.path.abspath('{0}/{1}/{2}'.format(__name__, self.data_dir, self.free_file))
        with open(ff_path) as f:
            self.free_domains = f.read().splitlines()

        df_path = os.path.abspath('{0}/{1}/{2}'.format(__name__, self.data_dir, self.disp_file))
        with open(df_path) as f:
            self.disp_domains = f.read().splitlines()

    def is_free(self, email):
        return self.domain_from_email(email) in self.free_domains

    def is_disposable(self, email):
        return self.domain_from_email(email) in self.disp_domains

    @staticmethod
    def domain_from_email(email):
        if '@' not in email:
            return

        if email[-1:] == '@':
            return

        return email.split('@')[1]
