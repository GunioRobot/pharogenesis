transformToDo: encoder
	" var _ rcvr. L1: [var <= arg1] Bfp(L2) [block body. var _ var + inc] Jmp(L1) L2: "
	| limit increment block initStmt test incStmt limitInit blockVar |
	"First check for valid arguments"
	(receiver isConstantNumber
		and: [(arguments last isMemberOf: BlockNode)
				and: [arguments last numberOfArguments = 1]])
		ifFalse: [^ false].
	arguments last firstArgument isVariableReference
		ifFalse: [^ false]. "As with debugger remote vars"
	arguments size = 3
		ifTrue: [increment _ arguments at: 2.
				increment isConstantNumber ifFalse: [^ false]]
		ifFalse: [increment _ encoder encodeLiteral: 1].
	arguments size < 3 ifTrue:   "transform to full form"
		[selector _ SelectorNode new key: #to:by:do: code: #macro].

	"Now generate auxiliary structures"
	block _ arguments last.
	blockVar _ block firstArgument.
	initStmt _ AssignmentNode new variable: blockVar value: receiver.
	limit _ arguments at: 1.
	limit isVariableReference | limit isConstantNumber
		ifTrue: [limitInit _ nil]
		ifFalse:  "Need to store limit in a var"
			[limit _ encoder autoBind: blockVar key , 'LimiT'.
			limitInit _ AssignmentNode new
					variable: limit
					value: (arguments at: 1)].
	test _ MessageNode new receiver: blockVar
			selector: (increment key > 0 ifTrue: [#<=] ifFalse: [#>=])
			arguments: (Array with: limit)
			precedence: precedence from: encoder.
	incStmt _ AssignmentNode new
			variable: blockVar
			value: (MessageNode new
				receiver: blockVar selector: #+
				arguments: (Array with: increment)
				precedence: precedence from: encoder).
	arguments _ (Array with: limit with: increment with: block)
		, (Array with: initStmt with: test with: incStmt with: limitInit).
	^ true