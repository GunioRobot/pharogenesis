on: anObject list: getListSel selected: getSelectionSel changeSelected: setSelectionSel menu: getMenuSel keystroke: keyActionSel

	self model: anObject.
	getListSelector _ getListSel.
	getSelectionSelector _ getSelectionSel.
	setSelectionSelector _ setSelectionSel.
	getMenuSelector _ getMenuSel.
	keystrokeActionSelector _ keyActionSel.
	autoDeselect _ true.
	self borderWidth: 1.
	self list: self getList.