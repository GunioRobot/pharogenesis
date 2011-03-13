printKeywords: key arguments: args on: aStream indent: level prefix: isPrefix
	| keywords indent noColons arg kwd hasBrackets doCrTab |
	args size = 0 ifTrue: [aStream space; nextPutAll: key. ^ self].
	keywords _ key keywords.
	noColons _ aStream dialect = #SQ00 and: [keywords first endsWith: ':'].
	doCrTab _ args size > 2 or:
		[{receiver} , args
			inject: false
			into: [:was :thisArg |
				was or: [(thisArg isKindOf: BlockNode)
					or: [(thisArg isKindOf: MessageNode) and: [thisArg precedence >= 3]]]]].
	1 to: (args size min: keywords size) do:
		[:i | arg _ args at: i.  kwd _ keywords at: i.
		doCrTab
			ifTrue: [aStream crtab: level+1. indent _ 1] "newline after big args"
			ifFalse: [aStream space. indent _ 0].
		noColons
			ifTrue: [aStream withStyleFor: (isPrefix ifTrue: [#prefixKeyword] ifFalse: [#keyword])
						do: [aStream nextPutAll: kwd allButLast; space].
					hasBrackets _ (arg isKindOf: BlockNode) or: [arg isKindOf: BlockNode].
					hasBrackets ifFalse: [aStream nextPutAll: '(']]
			ifFalse: [aStream nextPutAll: kwd; space].
		arg printOn: aStream indent: level + 1 + indent
			 	precedence: (precedence = 2 ifTrue: [1] ifFalse: [precedence]).
		noColons
			ifTrue: [hasBrackets ifFalse: [aStream nextPutAll: ')']]]