openFile: aPath
	pathToFile _ aPath.
	fileBits _ self primFileOpen: aPath.
	fileBits notNil ifTrue: 
		[fileIndex _ Smalltalk registerExternalObject: fileBits.
		self register.]
	