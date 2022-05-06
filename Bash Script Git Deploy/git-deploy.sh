#!/bin/bash
echo "Give message:"
read message
git add .
git commit -m"${message}"
if [ -n "$(git status - porcelain)" ];
then
	echo "It is clear!!"
else
	git status
	echo "Pushing data!"
	git push -u origin master
fi
