whileAsToDo: initStmt
	"Return nil, or a to:do: expression equivalent to this whileTrue:"
	| variable increment limit toDoBlock body test |
	(selector key == #whileTrue: and: [initStmt isMemberOf: AssignmentNode])
		ifFalse: [^ nil].
	variable _ initStmt variable.
	variable isConstantNumber  "Otherwise would decompile some "
		ifFalse: [^ nil].   " whiles into to:do:s that work differently."
	body _ arguments last statements.
	increment _ body last toDoIncrement: variable.
	(increment == nil or: [receiver statements size ~= 1])
		ifTrue: [^ nil].
	test _ receiver statements first.
	((test isMemberOf: MessageNode)
		and: [(limit _ test toDoLimit: variable) notNil])
		ifFalse: [^ nil].
	toDoBlock _ BlockNode new
			statements: (body copyFrom: 1 to: body size-1)
			returns: false.
	toDoBlock arguments: (Array with: variable).
	^ MessageNode new
		receiver: initStmt value
		selector: (SelectorNode new key: #to:by:do: code: #macro)
		arguments: (Array with: limit with: increment with: toDoBlock)
		precedence: precedence