stackOfSize: limit 
	"Answer an OrderedCollection of the top 'limit' contexts
		on the receiver's sender chain."

	| a stack cachedStackTop newLimit |
	stack _ OrderedCollection new.
	stack addLast: (a _ self).
	[(a _ a sender) ~~ nil and: [stack size < limit]]
		whileTrue:
			[a hideFromDebugger ifFalse: [stack addLast: a].
			a cachesStack ifTrue: [cachedStackTop := a cachedStackTop]].
	^cachedStackTop == nil 
		ifTrue: [stack]
		ifFalse:
			[newLimit := limit - stack size.
			newLimit > 0
				ifTrue: [stack addAllLast: (cachedStackTop stackOfSize: newLimit); yourself]
				ifFalse: [stack]]