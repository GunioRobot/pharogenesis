methodsWithCall: callName intoModule: moduleNameOrNil enabled: enabledFlag 
	^ ((self methodsWithCallEnabled: enabledFlag)
		select: (self blockSelectCallName: callName))
		select: (self blockSelectModuleName: moduleNameOrNil)