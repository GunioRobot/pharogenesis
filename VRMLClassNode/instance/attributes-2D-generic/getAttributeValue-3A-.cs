getAttributeValue: aVRMLNodeAttribute
	aVRMLNodeAttribute isEvent
		ifTrue:[^nil]
		ifFalse:[^self perform: aVRMLNodeAttribute getterName]