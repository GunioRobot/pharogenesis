buildPluggableList: aSpec
	| widget listClass getIndex setIndex |
	aSpec getSelected ifNil:[
		listClass := PluggableListMorphPlus.
		getIndex := aSpec getIndex.
		setIndex := aSpec setIndex.
	] ifNotNil:[
		listClass := PluggableListMorphByItemPlus.
		getIndex := aSpec getSelected.
		setIndex := aSpec setSelected.
	].
	widget := listClass on: aSpec model
				list: aSpec list
				selected: getIndex
				changeSelected: setIndex
				menu: aSpec menu
				keystroke: aSpec keyPress.
	self register: widget id: aSpec name.
	widget dragItemSelector: aSpec dragItem.
	widget dropItemSelector: aSpec dropItem.
	widget wantsDropSelector: aSpec dropAccept.
	widget autoDeselect: aSpec autoDeselect.
	self setFrame: aSpec frame in: widget.
	parent ifNotNil:[self add: widget to: parent].
	panes ifNotNil:[
		aSpec list ifNotNil:[panes add: aSpec list].
	].
	^widget