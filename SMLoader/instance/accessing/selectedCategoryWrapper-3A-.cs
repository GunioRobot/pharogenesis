selectedCategoryWrapper: aWrapper
	selectedCategoryWrapper := aWrapper.
	self selectedItemWrapper: nil.
	self changed: #selectedCategoryWrapper.
	self changed: #packageWrapperList.