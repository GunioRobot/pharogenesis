fileOutCategory: catName asHtml: useHtml
	"FileOut the named category, possibly in Html format."
	| fileStream |
	fileStream _ useHtml
		ifTrue: [(FileStream newFileNamed: self name , '-' , catName , '.html') asHtml]
		ifFalse: [FileStream newFileNamed: self name , '-' , catName , '.st'].
	fileStream header; timeStamp.
	self fileOutCategory: catName on: fileStream moveSource: false toFile: 0.
	fileStream trailer; close