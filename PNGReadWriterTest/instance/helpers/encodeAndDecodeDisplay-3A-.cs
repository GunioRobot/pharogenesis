encodeAndDecodeDisplay: depth
	| form |
	fileName := 'testDisplay', depth printString,'.png'.
	form := Form extent: (Display extent min: 560@560) depth: depth.
	Smalltalk isMorphic 
		ifTrue:[World fullDrawOn: form getCanvas]
		ifFalse:[Display displayOn: form].
	self encodeAndDecode: form.