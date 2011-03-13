isAFileNamed: fName
	| f |
	f _ self new open: fName forWrite: false.
	f == nil ifTrue: [^ false].
	f close.
	^ true