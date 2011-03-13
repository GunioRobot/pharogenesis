printOn: aStream 
	"Refer to the comment in Object|printOn:."

	aStream nextPutAll: 
		(self closed ifTrue: ['a closed '] ifFalse: ['an open ']).
	aStream nextPutAll: self class name.
	aStream nextPutAll: ' on '.
	pathName printOn: aStream