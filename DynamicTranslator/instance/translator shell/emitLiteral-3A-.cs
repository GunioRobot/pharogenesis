emitLiteral: literal
	"opPointer is pre-incremented!"

	self emitSkip: 1.
	self longAt: opPointer put: literal.