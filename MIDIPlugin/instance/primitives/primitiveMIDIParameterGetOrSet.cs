primitiveMIDIParameterGetOrSet
	"Backward compatibility"
	self export: true.
	interpreterProxy methodArgumentCount = 1
		ifTrue:[^self primitiveMIDIParameterGet]
		ifFalse:[^self primitiveMIDIParameterSet]