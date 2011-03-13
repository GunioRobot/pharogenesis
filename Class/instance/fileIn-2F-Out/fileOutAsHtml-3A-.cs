fileOutAsHtml: useHtml
	"File a description of the receiver onto a new file whose base name is the name of the receiver."

	| fileStream |
	fileStream _ useHtml
		ifTrue: [(FileStream newFileNamed: self name, FileDirectory dot, 'html') asHtml]
		ifFalse: [FileStream newFileNamed: self name, FileDirectory dot, 'st'].
	fileStream header; timeStamp.
	self sharedPools size > 0 ifTrue: [
		self shouldFileOutPools
			ifTrue: [self fileOutSharedPoolsOn: fileStream]].
	self fileOutOn: fileStream moveSource: false toFile: 0.
	fileStream trailer; close.
