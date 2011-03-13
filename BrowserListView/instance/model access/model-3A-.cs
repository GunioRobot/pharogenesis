model: aBrowser

	super model: aBrowser.
	self list: self getList.
	singleItemMode ifTrue: [selection _ 1]