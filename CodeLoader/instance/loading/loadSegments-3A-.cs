loadSegments: anArray
	"Load all the source files in the given array."
	| loader request reqName |
	loader := HTTPLoader default.
	segments := anArray collect:[:name |
		reqName := (FileDirectory extensionFor: name) isEmpty
			ifTrue: [FileDirectory fileName: name extension: ImageSegment compressedFileExtension]
			ifFalse: [name].
		request := self createRequestFor: reqName in: loader.
		name->request].
