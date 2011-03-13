testUnknownSelector
	self 
		should: 
			[self class 
				compile: 'griffle self reallyHopeThisIsntImplementedAnywhere'
				notifying: self]
		raise: UnknownSelector