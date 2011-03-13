selectInverseCategories
	categoriesSelected := categories asSet 
		removeAll: categoriesSelected;
		yourself.
	self changed: #categorySelected; updateClasses.