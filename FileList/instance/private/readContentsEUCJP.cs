readContentsEUCJP
	| f stream |
	f := directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	stream := String new writeStream.
	f converter: EUCJPTextConverter new.
	[f atEnd]
		whileFalse: [stream nextPut: f next].
	f close.
	^ stream contents