readContentsUTF8
	| f writeStream |
	f _ directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	writeStream _ WriteStream on: String new.
	f converter: UTF8TextConverter new.
	[f atEnd]
		whileFalse: [writeStream nextPut: f next].
	f close.
	^ writeStream contents