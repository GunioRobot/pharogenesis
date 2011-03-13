case: dist
	"statements = keyStmts CascadeFlag keyValueBlock ... keyStmts"

	| nextCase end thenJump stmtStream elements b node cases otherBlock |
	nextCase _ pc + dist.
	end _ limit.
	"Now add CascadeFlag & keyValueBlock to statements"
	statements addLast: stack removeLast; addLast: (self blockTo: nextCase).
	stack last == CascadeFlag
		ifFalse: "Last case"
			["ensure jump is within block (in case thenExpr returns wierdly I guess)"
			thenJump _ exit <= end ifTrue: [exit] ifFalse: [nextCase].
			stmtStream _ ReadStream on: (self popTo: stack removeLast).
			elements _ OrderedCollection new.
			b _ OrderedCollection new.
			[stmtStream atEnd] whileFalse:
				[(node _ stmtStream next) == CascadeFlag
					ifTrue:
						[elements addLast: (constructor
							codeMessage: (constructor codeBlock: b returns: false)
							selector: (constructor codeSelector: #-> code: #macro)
							arguments: (Array with: stmtStream next)).
						 b _ OrderedCollection new]
					ifFalse: [b addLast: node]].
			b size > 0 ifTrue: [self error: 'Bad cases'].
			cases _ constructor codeBrace: elements.
			otherBlock _ self blockTo: thenJump.
			stack addLast:
				(constructor
					codeMessage: stack removeLast
					selector: (constructor codeSelector: #caseOf:otherwise: code: #macro)
					arguments: (Array with: cases with: otherBlock))]