secHasSocketAccess
	self export: true.
	^self cCode: 'ioHasSocketAccess()'