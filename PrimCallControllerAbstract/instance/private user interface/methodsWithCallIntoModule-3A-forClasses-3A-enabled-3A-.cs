methodsWithCallIntoModule: moduleNameOrNil forClasses: classes enabled: enabledFlag 
	^ (self methodsWithCallForClasses: classes enabled: enabledFlag)
		select: (self blockSelectModuleName: moduleNameOrNil)