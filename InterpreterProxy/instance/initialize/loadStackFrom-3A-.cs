loadStackFrom: aContext
	self push: aContext receiver.
	method _ aContext method.
	argumentCount _ method numArgs.
	1 to: argumentCount do:[:i| self push: (aContext at: i) ].