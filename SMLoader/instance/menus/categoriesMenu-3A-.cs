categoriesMenu: aMenu 
	"Answer the categories-list menu."

	self selectedCategory 
		ifNotNil: [aMenu addList: self categorySpecificOptions; addLine].
	aMenu addList: self generalOptions.
	self addFiltersToMenu: aMenu.
	^aMenu