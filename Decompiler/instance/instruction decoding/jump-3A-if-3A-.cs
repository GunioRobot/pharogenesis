jump: dist if: condition

	| savePc elseDist sign elsePc elseStart end cond ifExpr thenBlock elseBlock thenJump
		elseJump condHasValue b isIfNil saveStack |
	stack last == CascadeFlag ifTrue: [^ self case: dist].
	elsePc _ lastPc.
	elseStart _ pc + dist.
	end _ limit.
	"Check for bfp-jmp to invert condition.
	Don't be fooled by a loop with a null body."
	sign _ condition.
	savePc _ pc.
	((elseDist _ self interpretJump) notNil and: [elseDist >= 0 and: [elseStart = pc]])
		ifTrue: [sign _ sign not.  elseStart _ pc + elseDist].
	pc _ savePc.
	ifExpr _ stack removeLast.
	(stack size > 0 and: [stack last == IfNilFlag])
		ifTrue: [stack removeLast.  isIfNil _ true]
		ifFalse: [isIfNil _ false].
	saveStack _ stack.
	stack _ OrderedCollection new.
	thenBlock _ self blockTo: elseStart.
	condHasValue _ hasValue or: [isIfNil].
	"ensure jump is within block (in case thenExpr returns)"
	thenJump _ exit <= end ifTrue: [exit] ifFalse: [elseStart].
	"if jump goes back, then it's a loop"
	thenJump < elseStart
		ifTrue:
			["Must be a while loop...
			thenJump will jump to the beginning of the while expr.  In the case of
			while's with a block in the condition, the while expr
			should include more than just the last expression: find all the
			statements needed by re-decompiling."
			stack _ saveStack.
			pc _ thenJump.
			b _ self statementsTo: elsePc.
			"discard unwanted statements from block"
			b size - 1 timesRepeat: [statements removeLast].
			statements addLast: (constructor
					codeMessage: (constructor codeBlock: b returns: false)
					selector: (constructor codeSelector: (sign ifTrue: [#whileFalse:] ifFalse: [#whileTrue:]) code: #macro)
					arguments: (Array with: thenBlock)).
			pc _ elseStart.
			self convertToDoLoop]
		ifFalse:
			["Must be a conditional..."
			elseBlock _ self blockTo: thenJump.
			elseJump _ exit.
			"if elseJump is backwards, it is not part of the elseExpr"
			elseJump < elsePc
				ifTrue: [pc _ lastPc].
			isIfNil
			ifTrue: [cond _ constructor
						codeMessage: ifExpr ifNilReceiver
						selector: (sign
							ifTrue: [constructor codeSelector: #ifNotNil: code: #macro]
							ifFalse: [constructor codeSelector: #ifNil: code: #macro])
						arguments: (Array with: thenBlock)]
			ifFalse: [cond _ constructor
						codeMessage: ifExpr
						selector: (constructor codeSelector: #ifTrue:ifFalse: code: #macro)
						arguments:
							(sign
								ifTrue: [Array with: elseBlock with: thenBlock]
								ifFalse: [Array with: thenBlock with: elseBlock])].
			stack _ saveStack.
			condHasValue
				ifTrue: [stack addLast: cond]
				ifFalse: [statements addLast: cond]]