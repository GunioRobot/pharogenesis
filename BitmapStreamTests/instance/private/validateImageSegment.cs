validateImageSegment
	| other externalSegmentFilename |
	externalSegmentFilename := 'bitmapStreamTest.extSeg'.
	[
	(ImageSegment new copyFromRootsForExport: (Array with: array))
		writeForExport: externalSegmentFilename.
	other := (FileDirectory default readOnlyFileNamed: externalSegmentFilename)
		fileInObjectAndCode
	] ensure: [ FileDirectory default deleteFileNamed: externalSegmentFilename ifAbsent: [ ] ]. 
	self assert: array = other originalRoots first