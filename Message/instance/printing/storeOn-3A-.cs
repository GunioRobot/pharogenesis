storeOn: aStream 
	"Refer to the comment in Object|storeOn:."

	aStream nextPut: $(.
	aStream nextPutAll: 'Message selector: '.
	selector storeOn: aStream.
	aStream nextPutAll: ' arguments: '.
	args storeOn: aStream.
	aStream nextPut: $)