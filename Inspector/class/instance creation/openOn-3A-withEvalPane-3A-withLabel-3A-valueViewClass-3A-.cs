openOn: anObject withEvalPane: withEval withLabel: label valueViewClass: valueViewClass
	| topView inspector listView valueView evalView |
	inspector _ self inspect: anObject.
	topView _ StandardSystemView new model: inspector.
	topView borderWidth: 1.

	listView _ PluggableListView on: inspector
		list: #fieldList
		selected: #selectionIndex
		changeSelected: #toggleIndex:
		menu: #fieldListMenu:
		keystroke: #inspectorKey:from:.
	listView window: (0 @ 0 extent: 40 @ 40).
	topView addSubView: listView.

	valueView _ valueViewClass new.
		"PluggableTextView or PluggableFormView"
	(valueView respondsTo: #getText) ifTrue: [
		valueView on: inspector 
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:].
	(valueViewClass inheritsFrom: FormView) ifTrue: [
		valueView model: inspector].
	valueView window: (0 @ 0 extent: 75 @ 40).
	topView addSubView: valueView toRightOf: listView.
	
	withEval ifTrue:
		[evalView _ PluggableTextView new on: inspector 
			text: #trash accept: #trash:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		evalView window: (0 @ 0 extent: 115 @ 20).
		evalView askBeforeDiscardingEdits: false.
		topView addSubView: evalView below: listView].
	topView label: label.
	topView minimumSize: 180 @ 120.
	topView setUpdatablePanesFrom: #(fieldList).
	topView controller open