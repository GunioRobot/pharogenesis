primitive: primID parameters: parmSpecs receiver: rcvrSpec

	| tMethod |
	tMethod _ TestTMethod new 
		fromContext: thisContext sender 
		primitive: primID 
		parameters: parmSpecs 
		receiver: rcvrSpec.
	^tMethod simulatePrologInContext: thisContext sender