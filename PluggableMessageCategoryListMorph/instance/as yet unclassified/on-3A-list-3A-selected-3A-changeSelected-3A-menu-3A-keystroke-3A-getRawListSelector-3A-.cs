on: anObject list: getListSel selected: getSelectionSel changeSelected: setSelectionSel menu: getMenuSel keystroke: keyActionSel getRawListSelector: getRawSel
	self model: anObject.
	getListSelector _ getListSel.
	getIndexSelector _ getSelectionSel.
	setIndexSelector _ setSelectionSel.
	getMenuSelector _ getMenuSel.
	keystrokeActionSelector _ keyActionSel.
	autoDeselect _ true.
	self borderWidth: 1.
	getRawListSelector _ getRawSel.
	self updateList.
	self selectionIndex: self getCurrentSelectionIndex.
	self initForKeystrokes