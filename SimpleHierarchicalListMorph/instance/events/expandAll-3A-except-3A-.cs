expandAll: aMorph except: aBlock
	| allChildren |
	(aBlock value: aMorph complexContents)
		ifFalse: [^self].
	aMorph toggleExpandedState.
	allChildren _ OrderedCollection new: 10.
	aMorph recursiveAddTo: allChildren.
	allChildren do: [:each | 
		(each canExpand
			and: [each isExpanded not])
			ifTrue: [self expandAll: each except: aBlock]].
	self installEventHandlerOn: allChildren