defaultTextPrinter
	"This is the global default TextPrinter instance."
	DefaultTextPrinter isNil ifTrue: [DefaultTextPrinter _ self new].
	^DefaultTextPrinter