nextImage
	"Read in the next GIF image from the stream. Read it all into
memory first for speed."

	| f thisImageColorTable |
	stream class == ReadWriteStream ifFalse: [
		stream binary.
		self on: (ReadWriteStream with: (stream contentsOfEntireFile))].

	localColorTable _ nil.
	self readHeader.
	f _ self readBody.
	self close.
	f == nil ifTrue: [^ self error: 'corrupt GIF file'].

	thisImageColorTable _ localColorTable ifNil: [colorPalette].
	transparentIndex ifNotNil: [
		transparentIndex + 1 > thisImageColorTable size ifTrue: [
			thisImageColorTable _ thisImageColorTable 
				forceTo: transparentIndex + 1 
				paddingWith: Color white
		].
		thisImageColorTable at: transparentIndex + 1 put: Color transparent
	].
	f colors: thisImageColorTable.
	^ f
