secHasFileAccess
	self export: true.
	^self cCode: 'ioHasFileAccess()'