secCanWriteImage
	self export: true.
	^self cCode: 'ioCanWriteImage()'