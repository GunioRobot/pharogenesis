writeSourceCodeFrom: aStream baseName: baseName isSt: stOrCsFlag useHtml: useHtml

	| extension converter f fileName |
	aStream contents isAsciiString ifTrue: [
		stOrCsFlag ifTrue: [
			extension _ (FileDirectory dot, FileStream st).
		] ifFalse: [
			extension _ (FileDirectory dot, FileStream cs).
		].
		converter _ MacRomanTextConverter new.
	] ifFalse: [
		stOrCsFlag ifTrue: [
			extension _ (FileDirectory dot, FileStream st "multiSt").
		] ifFalse: [
			extension _ (FileDirectory dot, FileStream cs "multiCs").
		].
		converter _ UTF8TextConverter new.
	].
	fileName _ useHtml ifTrue: [baseName, '.html'] ifFalse: [baseName, extension].
	f _ FileStream newFileNamed: fileName.
	f ifNil: [^ self error: 'Cannot open file'].
	(converter isMemberOf: UTF8TextConverter)
		ifTrue: [f binary.
			UTF8TextConverter writeBOMOn: f].
	f text.
	f converter: converter.
	f nextPutAll: aStream contents.
	f close.
