allImages
	| body colorTable |
	stream class == ReadWriteStream ifFalse: [
		stream binary.
		self on: (ReadWriteStream with: (stream contentsOfEntireFile))].
	localColorTable _ nil.
	forms _ OrderedCollection new.
	delays _ OrderedCollection new.
	comments _ OrderedCollection new.
	self readHeader.
	[(body _ self readBody) == nil]
		whileFalse: [colorTable _ localColorTable
						ifNil: [colorPalette].
			transparentIndex
				ifNotNil: [transparentIndex + 1 > colorTable size
						ifTrue: [colorTable _ colorTable forceTo: transparentIndex + 1 paddingWith: Color white].
					colorTable at: transparentIndex + 1 put: Color transparent].
			body colors: colorTable.
			forms add: body.
			delays add: delay].
	^ forms