print: aVRMLNode on: aVRMLStream indent: aLevel
	| newValue |
	newValue := aVRMLNode getAttributeValue: self.
	newValue = value ifTrue:[^self].
	aVRMLStream crtab: aLevel.
	VRMLWriter writeAttribute: self on: aVRMLStream value: newValue indent: aLevel.