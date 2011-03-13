formBrace
	"A #toBraceStream: selector has been encountered as part of a sequence:
		<Literal n> <Send toBraceStream:> <Pop> <Store#n> ... <Store#1>
	 where <Store#i> is either a <StorePop> or a sequence like the above.
	 The top of the stack must therefore be a LiteralNode with the key n.
	 Beneath that is usually the right-hand side of the assignment.
	 However, there may be an intervening pair of CascadeFlags and a number
	 beneath them.

	 Create a BraceNode and let it consume the pop & stores to determine its variables.
	 Create an AssignmentNode with the BraceNode as its variable and the
	 right-hand-side as its value.  Add the AssignmentNode to statements.

	 If two CascadeFlags are encountered instead of the right-hand-side, pop them
	 and the number beneath them to find the right-hand-side, and leave the
	 Assignment node on the stack instead of adding it to statements
	 (this happens in cases like  x _ {a. b} _ ...)."

	| var expr dest |
	var _ constructor codeBrace: stack removeLast literalValue fromBytes: self.
	(expr _ stack removeLast) == CascadeFlag
		ifTrue: "multiple assignment, more to come"
			[stack removeLast; removeLast. "CascadeFlag, number"
			expr _ stack removeLast.
			dest _ stack]
		ifFalse: "store and pop"
			[dest _ statements].
	dest addLast: (constructor codeAssignTo: var value: expr)