fetchExtension
	"This method uses the preIncrement builtin function which has no Smalltalk equivalent. Thus, it must be overridden in the simulator."
	| ext |
	self inline: true.
	ext _ self longAt: (localIP _ localIP + 4).
	"localIP _ localIP + 4."		"skip empty slot"
	^self integerValueOf: ext