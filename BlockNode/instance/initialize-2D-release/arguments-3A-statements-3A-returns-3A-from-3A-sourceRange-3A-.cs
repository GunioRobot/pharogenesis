arguments: argNodes statements: statementsCollection returns: returnBool from: encoder sourceRange: range
	"Compile."

	encoder noteSourceRange: range forNode: self.
	^self
		arguments: argNodes
		statements: statementsCollection
		returns: returnBool
		from: encoder