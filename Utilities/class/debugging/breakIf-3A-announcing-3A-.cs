breakIf: aBoolean announcing: aMessage
	"If aBoolean is true, halt, with the given message.  1/26/96 sw"
	aBoolean ifTrue:
		[self break: aMessage]