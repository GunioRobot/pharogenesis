classListIndex: anInteger

	classListIndex _ anInteger.
	classListIndex > 0 ifTrue:
		[self dependents do:
			[:dep | ((dep isKindOf: PluggableListView) and:
				[dep setSelectionSelectorIs: #classListIndex:])
					ifTrue: [dep controller controlTerminate]].
		Browser fullOnClass: self selectedClass selector: self selectedMessageName.
		"classListIndex _ 0"]