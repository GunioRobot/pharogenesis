readFromFileNamed: fName
	| file fileCode form |
	file _ FileStream readOnlyFileNamed: fName.
	fileCode _ file next asciiValue.
	file close.
	form _ (fileCode = 2
		ifTrue: [Form newFromFileNamed: fName]
		ifFalse: [Smalltalk gifReaderClass formFromFileNamed: fName]).
	self image: form.
