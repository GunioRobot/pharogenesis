case: dist
	"statements = keyStmts CascadeFlag keyValueBlock ... keyStmts"

	| nextCase thenJump stmtStream elements b node cases otherBlock myExits |
	nextCase _ pc + dist.

	"Now add CascadeFlag & keyValueBlock to statements"
	statements addLast: stack removeLast.
	stack addLast: CaseFlag. "set for next pop"
	statements addLast: (self blockForCaseTo: nextCase).

	stack last == CaseFlag
		ifTrue: "Last case"
			["ensure jump is within block (in case thenExpr returns wierdly I guess)"
			stack removeLast. "get rid of CaseFlag"
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
			
			"try find the end of the case"
			myExits := caseExits removeLast: elements size.
			myExits := myExits reject: [ :e | e isNil or: [ e < 0 or: [ e > method size ] ] ].
			myExits isEmpty
				ifTrue: [ thenJump := nextCase ]
				ifFalse: [ thenJump := myExits min ].
			
			otherBlock _ self blockTo: thenJump.
			stack addLast:
				(constructor
					codeMessage: stack removeLast
					selector: (constructor codeSelector: #caseOf:otherwise: code: #macro)
					arguments: (Array with: cases with: otherBlock)).
					
			myExits isEmpty ifTrue:[
				"all branches returned; pop off the statement"
				statements addLast: stack removeLast. ] ].