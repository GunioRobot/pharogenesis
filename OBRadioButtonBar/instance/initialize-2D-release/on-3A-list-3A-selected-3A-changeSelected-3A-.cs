on: aModel list: listSelector selected: selectionGetter changeSelected: selectionSetter 
	self model: aModel.
	selection _ 0.
	getListSelector _ listSelector.
	getSelectionSelector _ selectionGetter.
	setSelectionSelector _ selectionSetter.
	self initGeometry.
	self updateList.