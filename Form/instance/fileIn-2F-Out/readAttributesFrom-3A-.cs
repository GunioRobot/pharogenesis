readAttributesFrom: aBinaryStream
	| offsetX offsetY |
	depth _ aBinaryStream next.
	(self depth isPowerOfTwo and: [self depth between: 1 and: 32])
		ifFalse: [self error: 'invalid depth; bad Form file?'].
	width _ aBinaryStream nextWord.
	height _ aBinaryStream nextWord.
	offsetX  _ aBinaryStream nextWord.
	offsetY _ aBinaryStream nextWord.
	offsetX > 32767 ifTrue: [offsetX _ offsetX - 65536].
	offsetY > 32767 ifTrue: [offsetY _ offsetY - 65536].
	offset _ Point x: offsetX y: offsetY.
	
