shutdownModule
	self export: true.
	^self cCode: 'joystickShutdown()' inSmalltalk:[true]