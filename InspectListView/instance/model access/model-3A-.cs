model: anInspector

	super model: anInspector.
	self list: model fieldList.
	selection _ model selectionIndex