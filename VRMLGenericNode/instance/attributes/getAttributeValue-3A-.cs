getAttributeValue: aVRMLAttribute
	^(self attributes at: aVRMLAttribute ifAbsent:[aVRMLAttribute]) value