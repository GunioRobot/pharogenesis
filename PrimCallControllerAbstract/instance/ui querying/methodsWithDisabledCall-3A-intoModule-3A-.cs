methodsWithDisabledCall: primName intoModule: moduleNameOrNil
	^ self methodsWithCall: primName intoModule: moduleNameOrNil enabled: false