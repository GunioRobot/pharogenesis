printOn: aVRMLStream indent: aLevel
	"aVRMLStream crtab: aLevel."
	aVRMLStream nextPutAll: self attributeClass; space; nextPutAll: self type; space.
	VRMLWriter writeAttribute: self on: aVRMLStream value: value indent: aLevel.