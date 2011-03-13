stackOfSize: limit 
	"Answer an OrderedCollection of the top 'limit' contexts
		on the receiver's sender chain."

	| a stack |
	stack _ OrderedCollection new.
	stack addLast: (a _ self).
	[(a _ a sender) ~~ nil and: [stack size < limit]]
		whileTrue: [stack addLast: a].
	^ stack