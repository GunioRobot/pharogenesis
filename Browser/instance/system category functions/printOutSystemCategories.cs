printOutSystemCategories
	"Print a description of each class in the selected category as Html."

	systemCategoryListIndex ~= 0
		ifTrue: [systemOrganizer fileOutCategory: self selectedSystemCategoryName
								asHtml: true ]