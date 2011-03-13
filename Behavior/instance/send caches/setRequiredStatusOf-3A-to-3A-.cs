setRequiredStatusOf: selector to: aBoolean
	aBoolean 
		ifTrue: [self requiredSelectorsCache addRequirement: selector]
		ifFalse: [self requiredSelectorsCache removeRequirement: selector].