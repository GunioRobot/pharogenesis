compiledMethodsToExampleModule
	^ self methodSelectorsToExampleModule
		collect: [:sel | self class >> sel]