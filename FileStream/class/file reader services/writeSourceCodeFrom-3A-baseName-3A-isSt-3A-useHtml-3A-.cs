writeSourceCodeFrom: aStream baseName: baseName isSt: stOrCsFlag useHtml: useHtml

	| extension converter f fileName |
	aStream contents isAsciiString ifTrue: [
		stOrCsFlag ifTrue: [
			extension := (FileDirectory dot, FileStream st).
		] ifFalse: [
			extension := (FileDirectory dot, FileStream cs).
		].
		converter := MacRomanTextConverter new.
	] ifFalse: [
		stOrCsFlag ifTrue: [
			extension := (FileDirectory dot, FileStream st "multiSt").
		] ifFalse: [
			extension := (FileDirectory dot, FileStream cs "multiCs").
		].
		converter := UTF8TextConverter new.
	].
	fileName := useHtml ifTrue: [baseName, '.html'] ifFalse: [baseName, extension].
	f := FileStream newFileNamed: fileName.
	f ifNil: [^ self error: 'Cannot open file'].
	(converter isMemberOf: UTF8TextConverter)
		ifTrue: [f binary.
			UTF8TextConverter writeBOMOn: f].
	f text.
	f converter: converter.
	f nextPutAll: aStream contents.
	f close.
