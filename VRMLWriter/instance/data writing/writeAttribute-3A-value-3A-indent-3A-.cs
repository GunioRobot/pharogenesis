writeAttribute: aVRMLNodeAttribute value: value indent: aLevel
	self nextPutAll: aVRMLNodeAttribute name.
	self space.
	self perform: (VRMLFieldTypes at: aVRMLNodeAttribute type)
			with: aVRMLNodeAttribute
			with: value
			with: aLevel.
	self crtab: aLevel.