unlinkedSend: litSel nArgs: nArgs type: type
	"litSel is the literal selector (an integer index or Symbol depening on configuration).
	nArgs is the argument count (a raw integer).
	type is {Short,[Double]Extended}SendType."

	| sel rcvr |
	self inline: true.

	UseInlineCache ifTrue: [
		rcvr _ self internalStackValue: nArgs.
		sel _ self decodeLiteralSelector: litSel.
		self externalizeIPandSP.
		self linkAndSendSelector: sel to: rcvr nArgs: nArgs type: type.
		self internalizeIPandSP.
	] ifFalse: [
		messageSelector _ self decodeLiteralSelector: litSel.
		argumentCount _ nArgs.
		self normalSend.			"will this confuse the shared code handling?"
	]