importImageFromDisk
	| aName m f |
	aName _ Utilities chooseFileWithSuffix: ''.  "all files"
	aName ifNil: [^ self].
	f _ Form fromFileNamed: aName.
	f ifNil: [^ self error: 'unrecognized image file format'].
	m _ self drawingClass new form: f.
	self attachMorph: m.
