fileOutMethod: selector asHtml: useHtml
	"Write source code of a single method on a file in .st or .html format"
	| fileStream nameBody |
	(self includesSelector: selector) ifFalse: [^ self halt: 'Selector not found'].
	nameBody _ self name , '-' , (selector copyReplaceAll: ':' with: '').
	fileStream _ useHtml
		ifTrue: [(FileStream newFileNamed: nameBody , '.html') asHtml]
		ifFalse: [FileStream newFileNamed: nameBody , '.st'].
	fileStream header; timeStamp.
	self printMethodChunk: selector withPreamble: true
		on: fileStream moveSource: false toFile: 0.
	fileStream close