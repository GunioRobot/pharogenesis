print: aVRMLNode on: aVRMLStream indent: level

	aVRMLStream nextPutAll: name.
	aVRMLStream space.
	aVRMLStream nextPut: ${; space; space.
	self attributes do:[:attr|
		attr print: aVRMLNode on: aVRMLStream indent: level + 1.
	].
	aVRMLStream skip: -1.
	aVRMLStream nextPut:$}.