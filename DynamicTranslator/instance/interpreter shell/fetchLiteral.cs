fetchLiteral
	"This method uses the preIncrement builtin function which has no Smalltalk equivalent. Thus, it must be overridden in the simulator."

	self inline: true.
	^self longAt: (localIP _ localIP + 4)