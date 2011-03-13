buildPluggableMultiSelectionList: aSpec
	| widget listClass |
	aSpec getSelected ifNotNil:[^self error:'There is no PluggableListMorphOfManyByItem'].
	listClass := PluggableListMorphOfMany.
	widget := listClass on: aSpec model
		list: aSpec list
		primarySelection: aSpec getIndex
		changePrimarySelection: aSpec setIndex
		listSelection: aSpec getSelectionList
		changeListSelection: aSpec setSelectionList
		menu: aSpec menu.
	self register: widget id: aSpec name.
	widget keystrokeActionSelector: aSpec keyPress.
	self setFrame: aSpec frame in: widget.
	parent ifNotNil:[self add: widget to: parent].
	panes ifNotNil:[
		aSpec list ifNotNil:[panes add: aSpec list].
	].
	^widget