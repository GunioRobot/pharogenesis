classPaneNewSelection: arg1
	arg1 ifNil: [^ categoryPane list: Array new].
	categoryPane list: self selectedClassOrMetaClass organization categories