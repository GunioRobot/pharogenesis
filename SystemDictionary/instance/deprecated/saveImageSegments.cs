saveImageSegments
	| haveSegs oldImageSegDir newImageSegDir |
	self deprecated: 'Use SmalltalkImage current saveImageSegments'.
	haveSegs := false.
	self
		at: #ImageSegment
		ifPresent: [:theClass | (haveSegs := theClass instanceCount ~= 0)
				ifTrue: [oldImageSegDir := theClass segmentDirectory]].
	haveSegs
		ifTrue: [self
				at: #ImageSegment
				ifPresent: [:theClass | 
					newImageSegDir := theClass segmentDirectory.
					"create the folder"
					oldImageSegDir fileNames
						do: [:theName | 
							| imageSegmentName | 
							"copy all segment files"
							imageSegmentName := oldImageSegDir pathName , FileDirectory slash , theName.
							newImageSegDir copyFileWithoutOverwriteConfirmationNamed: imageSegmentName toFileNamed: theName]]]