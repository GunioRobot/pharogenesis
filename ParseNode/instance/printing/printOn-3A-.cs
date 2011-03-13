printOn: aStream 
	"Refer to the comment in Object|printOn:."

	aStream nextPutAll: '{'.
	self printOn: aStream indent: 0.
	aStream nextPutAll: '}'