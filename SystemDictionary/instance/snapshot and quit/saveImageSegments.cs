saveImageSegments

	| haveSegs oldImageSegDir newImageSegDir |
	haveSegs _ false.
	Smalltalk at: #ImageSegment ifPresent: [:theClass | 
		(haveSegs _ theClass instanceCount ~= 0) ifTrue: [
			oldImageSegDir _ theClass segmentDirectory]].
	haveSegs ifTrue: [
		Smalltalk at: #ImageSegment ifPresent: [:theClass |
			newImageSegDir _ theClass segmentDirectory.	"create the folder"
			oldImageSegDir fileNames do: [:theName | "copy all segment files"
				| imageSegmentName |
				imageSegmentName _ oldImageSegDir pathName, FileDirectory slash, theName.
				newImageSegDir 
					copyFileWithoutOverwriteConfirmationNamed: imageSegmentName
					toFileNamed: theName]]].
