validateImageSegment
	"array is set up with an array."
	| other filename |
	filename := 'bitmapStreamTest.extSeg'.

	FileDirectory default deleteFileNamed: filename ifAbsent: [ ].

	(ImageSegment new copyFromRootsForExport: (Array with: array))
         writeForExport: filename.

	other := (FileDirectory default readOnlyFileNamed: filename)
		fileInObjectAndCode.

	self assert: array = other originalRoots first