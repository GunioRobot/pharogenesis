fileOutCategory: category asHtml: useHtml
	"FileOut all the classes in the named system category."
	| fileStream |
	fileStream _ useHtml
		ifTrue: [(FileStream newFileNamed: category , '.html') asHtml]
		ifFalse: [FileStream newFileNamed: category , '.st'].
	self fileOutCategory: category on: fileStream initializing: true.
	fileStream close