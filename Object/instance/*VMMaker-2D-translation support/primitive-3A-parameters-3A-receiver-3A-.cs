primitive: primID parameters: parmSpecs receiver: rcvrSpec
"belongs in CCG package"
	| tMethod |
	tMethod _ SmartSyntaxPluginTMethod new 
		fromContext: thisContext sender 
		primitive: primID 
		parameters: parmSpecs 
		receiver: rcvrSpec.
	^tMethod simulatePrologInContext: thisContext sender