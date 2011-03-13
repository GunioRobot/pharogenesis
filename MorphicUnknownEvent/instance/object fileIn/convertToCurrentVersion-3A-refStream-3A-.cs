convertToCurrentVersion: varDict refStream: smartRefStrm
	
	type ifNil: [type _ #startSound].
	source ifNil: [source _ varDict at: 'sourceHand'].
	argument ifNil: [argument _ varDict at: 'sound' ifAbsent: [nil]].	"???"
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

