readContentsAsEncoding: encodingName
	| f writeStream converter c |
	f _ directory oldFileOrNoneNamed: self fullName.
	f ifNil: [^ 'For some reason, this file cannot be read'].
	writeStream _ WriteStream on: String new.
	converter _ TextConverter defaultConverterClassForEncoding: encodingName.
	converter ifNil: [^ 'This encoding is not supported'].
	f converter: converter new.
	f wantsLineEndConversion: true.
	[f atEnd or: [(c _ f next) isNil]]
		whileFalse: [writeStream nextPut: c].
	f close.
	^ writeStream contents