#!/usr/bin/python3
import random
from random import randint
import string
import sys

class bcolors:
	red = '\033[91m'
	yellow = '\033[93m'
	green = '\033[92m'
	cyan = '\033[96m'
	reset = '\033[0m'

def main():
	length = 8

	try:
		if len(sys.argv[1:]) > 1:
			return print(f"The accepted arguments are:\n{printInColor(bcolors.red, 'randompassword.py, or randompassword.py <length of the password>')}")

		if int(sys.argv[1]) > 0:
			try:
				length = int(sys.argv[1])
			except:
				pass
	except:
		pass

	print(printInColor(bcolors.cyan, genPassword(length)))

def printInColor(color, string):

	return f"{color}{string}{bcolors.reset}"

def genPassword(length):
	numberCount = randint(int(length // 4), int(length // 2))
	lettersAndNumbers = []

