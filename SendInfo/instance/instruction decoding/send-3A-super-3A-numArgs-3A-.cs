send: selector super: superFlag numArgs: numArgs 
	"Simulate the action of bytecodes that send a message with  
	selector. superFlag, tells whether the receiver of the  
	message was 'super' in the source. The arguments  
	of the message are found in the top numArgs locations on the  
	stack and the receiver just below them."
	| stackTop |
	selector == #blockCopy:
		ifTrue: ["self assert: [numArgs = 1]."
			isStartOfBlock _ true.
			numBlockArgs _ self pop.
			^ self].
	self pop: numArgs.
	stackTop _ self pop.
	superFlag
		ifTrue: [self addSuperSentSelector: selector]
		ifFalse: [stackTop == #self
				ifTrue: [self tallySelfSendsFor: selector].
			stackTop == #class
				ifTrue: [self addClassSentSelector: selector]].
	self
		push: ((selector == #class and: [stackTop == #self])
				ifTrue: [#class]
				ifFalse: [#stuff])