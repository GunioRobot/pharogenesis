writeAttribute: aVRMLNodeAttribute on: aVRMLStream value: value indent: aLevel
	aVRMLStream nextPutAll: aVRMLNodeAttribute name.
	aVRMLStream space.
	self perform: (VRMLFieldTypes at: aVRMLNodeAttribute type)
			with: value
			with: aVRMLStream
			with: aLevel.
	aVRMLStream crtab: aLevel.