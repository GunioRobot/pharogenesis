methodsWithFailedCallIntoModule: moduleNameOrNil 
	^ self methodsWithFailedCall
		select: (self blockSelectModuleName: moduleNameOrNil)