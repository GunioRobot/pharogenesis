nextImage
	"Read in the next GIF image from the stream. Read it all into
memory first for speed."

	| f |
	stream class == ReadWriteStream ifFalse: [
		(stream respondsTo: #binary) ifTrue: [stream binary].
		self on: (ReadWriteStream with: (stream contentsOfEntireFile))].

	self readHeader.
	f _ self readBody.
	self close.
	f == nil ifTrue: [^ self error: 'corrupt GIF file'].

	transparentIndex ifNotNil: [
		transparentIndex + 1 > colorPalette size ifTrue: [
			colorPalette _ colorPalette forceTo: transparentIndex + 1 paddingWith: Color white].
		colorPalette at: transparentIndex + 1 put: Color transparent].
	f colors: colorPalette.
	^ f
