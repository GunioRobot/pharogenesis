printOn: aStream
	aStream nextPutAll: 'IRCChannel '.
	aStream nextPutAll: self name.
	aStream nextPutAll: ' ('.
	aStream nextPutAll: numUsers printString.
	aStream nextPutAll: ')'.