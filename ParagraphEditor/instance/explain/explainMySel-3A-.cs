explainMySel: symbol 
	"Is symbol the selector of this method?  Is it sent by this method?  If 
	not, then expalin will call (explainPartSel:) to see if it is a fragment of a 
	selector sent here.  If not, explain will call (explainAnySel:) to catch any 
	selector. "

	| lits classes msg |
	(model respondsTo: #selectedMessageName) ifFalse: [^ nil].
	(msg _ model selectedMessageName) ifNil: [^nil].	"not in a message"
	classes _ Smalltalk allClassesImplementing: symbol.
	classes size > 12
		ifTrue: [classes _ 'many classes']
		ifFalse: [classes _ 'these classes ' , classes printString].
	msg = symbol
		ifTrue: [^ '"' , symbol , ' is the selector of this very method!  It is defined in ',
			classes , '.  To see the other definitions, go to the message list pane and use yellowbug to select ''implementors''."']
		ifFalse: 
			[lits _ (model selectedClassOrMetaClass compiledMethodAt:
				msg) messages.
			(lits detect: [:each | each == symbol]
				ifNone: [])
				== nil ifTrue: [^nil].
			^ '"' , symbol , ' is a message selector which is defined in ', classes , '.  To see the definitions, go to the message list pane and use yellowbug to select ''messages''."'].