methodsWithCallIntoModule: moduleNameOrNil enabled: enabledFlag 
	^ (self methodsWithCallEnabled: enabledFlag)
		select: (self blockSelectModuleName: moduleNameOrNil)