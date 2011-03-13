fileName: fileName extension: fileExtension
	| extension |
	extension _ FileDirectory dot , fileExtension.
	^(fileName endsWith: extension)
		ifTrue: [fileName]
		ifFalse: [fileName , extension].