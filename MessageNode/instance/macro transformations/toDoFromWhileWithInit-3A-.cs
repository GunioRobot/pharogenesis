toDoFromWhileWithInit: initStmt
	"Return nil, or a to:do: expression equivalent to this whileTrue:"
	| variable increment limit toDoBlock body test |
	(selector key == #whileTrue:
		and: [(initStmt isMemberOf: AssignmentNode) and:
				[initStmt variable isTemp]])
		ifFalse: [^ nil].
	body _ arguments last statements.
	variable _ initStmt variable.
	increment _ body last toDoIncrement: variable.
	(increment == nil or: [receiver statements size ~= 1])
		ifTrue: [^ nil].
	test _ receiver statements first.
	"Note: test chould really be checked that <= or >= comparison
	jibes with the sign of the (constant) increment"
	((test isMemberOf: MessageNode)
		and: [(limit _ test toDoLimit: variable) notNil])
		ifFalse: [^ nil].
	toDoBlock _ BlockNode new
			statements: body allButLast
			returns: false.
	toDoBlock arguments: (Array with: variable).
	^ MessageNode new
		receiver: initStmt value
		selector: (SelectorNode new key: #to:by:do: code: #macro)
		arguments: (Array with: limit with: increment with: toDoBlock)
		precedence: precedence