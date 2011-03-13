progressUpdate: aVRMLStream
	infoBar ifNil:[^self].
	infoBar value: (aVRMLStream position * 100 // aVRMLStream size).