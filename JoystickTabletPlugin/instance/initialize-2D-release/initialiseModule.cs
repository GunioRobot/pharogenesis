initialiseModule
	self export: true.
	^self cCode: 'joystickInit()' inSmalltalk:[true]