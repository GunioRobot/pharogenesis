categoryPaneNewSelection: arg1
	arg1 ifNil: [^ messagePane list: Array new].
	messagePane list: (self selectedClassOrMetaClass organization listAtCategoryNamed: arg1)