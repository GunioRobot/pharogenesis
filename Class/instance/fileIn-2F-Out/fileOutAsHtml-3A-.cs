fileOutAsHtml: useHtml
	"Create a file whose name is the name of the receiver with '.st' as the 
	extension, and file a description of the receiver onto it."
	| fileStream |
	fileStream _ useHtml
		ifTrue: [(FileStream newFileNamed: self name , '.html') asHtml]
		ifFalse: [FileStream newFileNamed: self name , '.st'].
	fileStream header; timeStamp.
	self sharedPools size > 0 ifTrue:
		[self shouldFileOutPools
			ifTrue: [self fileOutSharedPoolsOn: fileStream]].
	self fileOutOn: fileStream moveSource: false toFile: 0.
	fileStream trailer; close