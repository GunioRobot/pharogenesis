printOn: aStream
	super printOn: aStream.
	submorphs size > 0
		ifFalse:
			[aStream nextPutAll: ' with no transformee!']
		ifTrue:
			[aStream nextPutAll: ' on ', submorphs first printString]