readContentsEUCJP
	| f writeStream |
	f _ directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	writeStream _ WriteStream on: String new.
	f converter: EUCJPTextConverter new.
	[f atEnd]
		whileFalse: [writeStream nextPut: f next].
	f close.
	^ writeStream contents