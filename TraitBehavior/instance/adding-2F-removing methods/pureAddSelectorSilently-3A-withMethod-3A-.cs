pureAddSelectorSilently: selector withMethod: compiledMethod
	self methodDictAddSelectorSilently: selector withMethod: compiledMethod.
	self registerLocalSelector: selector