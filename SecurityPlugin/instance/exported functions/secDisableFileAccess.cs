secDisableFileAccess
	self export: true.
	^self cCode: 'ioDisableFileAccess()'