nextTagPut: tag length: length
	"Write the next tag."
	length >= 16r3F ifTrue:[
		self nextWordPut: (tag bitShift: 6) + 16r3F.
		self nextULongPut: length.
	] ifFalse:[
		self nextWordPut: (tag bitShift: 6) + length.
	].