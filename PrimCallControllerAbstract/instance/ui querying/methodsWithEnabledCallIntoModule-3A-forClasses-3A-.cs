methodsWithEnabledCallIntoModule: moduleNameOrNil forClasses: classes 
	^ self
		methodsWithCallIntoModule: moduleNameOrNil
		forClasses: classes
		enabled: true