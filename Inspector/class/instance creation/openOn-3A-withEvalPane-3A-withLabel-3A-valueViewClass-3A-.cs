openOn: anObject withEvalPane: withEval withLabel: label valueViewClass: valueViewClass
	| topView inspector listView valueView evalView |
	inspector _ self inspect: anObject.
	topView _ StandardSystemView new model: inspector.

	listView _ InspectListView new model: inspector.
		(inspector isMemberOf: DictionaryInspector)
			ifTrue: [listView controller: DictionaryListController new].
		listView window: (0 @ 0 extent: 40 @ 40).
		listView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
		topView addSubView: listView.
	valueView _ valueViewClass new model: inspector.
		valueView window: (0 @ 0 extent: 75 @ 40).
		valueView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
		topView addSubView: valueView toRightOf: listView.
withEval ifTrue:
	[evalView _ StringHolderView new
					model: (InspectorTrash for: inspector object).
		evalView window: (0 @ 0 extent: 115 @ 20).
		evalView borderWidthLeft: 2 right: 2 top: 0 bottom: 2.
		topView addSubView: evalView below: listView].
	topView label: label.
	topView minimumSize: 180 @ 120.
	topView controller open