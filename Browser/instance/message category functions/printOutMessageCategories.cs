printOutMessageCategories
	"Print a description of the selected message category of the selected class 
	onto an external file in Html format."

	messageCategoryListIndex ~= 0
		ifTrue: 
			[self selectedClassOrMetaClass fileOutCategory: self selectedMessageCategoryName
										asHtml: true]