printOn: aStream 
	"Refer to the comment in Object|printOn:."
 
	aStream nextPutAll: 'a Message with selector: '.
	selector printOn: aStream.
	aStream nextPutAll: ' and arguments: '.
	args printOn: aStream.
	^aStream