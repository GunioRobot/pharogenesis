printOutSystemCategory
	"Print a description of each class in the selected category as Html."

Cursor write showWhile:
	[systemCategoryListIndex ~= 0
		ifTrue: [systemOrganizer fileOutCategory: self selectedSystemCategoryName
								asHtml: true ]]
