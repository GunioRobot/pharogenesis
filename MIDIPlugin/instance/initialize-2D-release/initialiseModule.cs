initialiseModule
	self export: true.
	^self cCode: 'midiInit()' inSmalltalk:[true]