secDisableSocketAccess
	self export: true.
	^self cCode: 'ioDisableSocketAccess()'