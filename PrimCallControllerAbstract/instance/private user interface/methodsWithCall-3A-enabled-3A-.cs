methodsWithCall: callName enabled: enabledFlag 
	^ (self methodsWithCallEnabled: enabledFlag)
		select: (self blockSelectCallName: callName)