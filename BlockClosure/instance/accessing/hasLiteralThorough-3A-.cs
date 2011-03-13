hasLiteralThorough: literal
	"Answer true if literal is identical to any literal imbedded in my method"

	method == literal ifTrue: [^ true].
	^ method hasLiteralThorough: literal from: self