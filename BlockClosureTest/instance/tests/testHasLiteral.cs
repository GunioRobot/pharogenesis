testHasLiteral
	"self debug: #testComparing"

	self shouldnt: [closure hasLiteralThorough: #exemple]
		raise: Error.
	self assert: (closure hasLiteralThorough: #exemple) not