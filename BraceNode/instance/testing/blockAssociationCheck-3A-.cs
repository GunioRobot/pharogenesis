blockAssociationCheck: encoder
	"If all elements are MessageNodes of the form [block]->[block], and there is at
	 least one element, answer true.
	 Otherwise, notify encoder of an error."

	elements size = 0
		ifTrue: [^encoder notify: 'At least one case required'].
	elements with: sourceLocations do:
			[:x :loc |
			(x 	isMessage: #->
				receiver:
					[:rcvr |
					(rcvr isKindOf: BlockNode) and: [rcvr numberOfArguments = 0]]
				arguments:
					[:arg |
					(arg isKindOf: BlockNode) and: [arg numberOfArguments = 0]])
			  ifFalse:
				[^encoder notify: 'Association between 0-argument blocks required' at: loc]].
	^true