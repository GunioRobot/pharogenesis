expand: aMorph to: level
	| allChildren |
	aMorph toggleExpandedState.
	allChildren _ OrderedCollection new: 10.
	aMorph recursiveAddTo: allChildren.
	allChildren do: [:each | 
		((each canExpand
			and: [each isExpanded not])
			and: [level > 0])
			ifTrue: [self expand: each to: level-1]].
	self installEventHandlerOn: allChildren