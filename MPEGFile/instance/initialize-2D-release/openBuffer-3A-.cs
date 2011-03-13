openBuffer: aByteArray
	pathToFile := nil.
	buffer _ aByteArray.
	fileBits := self primFileOpenABuffer: aByteArray size: aByteArray size.
	fileBits notNil ifTrue: 
		[fileIndex := Smalltalk registerExternalObject: fileBits.
		self register.]
	