addAttribute: aVRMLNodeAttribute
	self attributes add: aVRMLNodeAttribute.
	self attrDict at: aVRMLNodeAttribute name put: aVRMLNodeAttribute.