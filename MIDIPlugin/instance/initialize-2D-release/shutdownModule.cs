shutdownModule
	self export: true.
	^self cCode: 'midiShutdown()' inSmalltalk:[true]