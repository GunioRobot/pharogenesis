methodsWithFailedCallIntoModule: moduleNameOrNil forClasses: classes
	^ (self methodsWithFailedCallForClasses: classes)
		select: (self blockSelectModuleName: moduleNameOrNil)