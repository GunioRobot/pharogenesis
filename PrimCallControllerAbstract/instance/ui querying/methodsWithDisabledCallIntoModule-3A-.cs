methodsWithDisabledCallIntoModule: moduleNameOrNil
	^ self methodsWithCallIntoModule: moduleNameOrNil enabled: false