loadSegments: anArray
	"Load all the source files in the given array."
	| loader request reqName |
	loader _ HTTPLoader default.
	segments _ anArray collect:[:name |
		reqName _ (FileDirectory extensionFor: name) isEmpty
			ifTrue: [FileDirectory fileName: name extension: ImageSegment compressedFileExtension]
			ifFalse: [name].
		request _ self createRequestFor: reqName in: loader.
		name->request].
