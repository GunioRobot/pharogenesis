plotPitchFromString: aString
	^ self plotPitchFromStream: (ReadStream on: aString)