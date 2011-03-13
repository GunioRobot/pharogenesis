newCategoryListPanel
	"Answer a groupbox for the categories list."
	
	^(UITheme builder
		newGroupbox: 'Categories' translated
		for: (self newCategoryList 
			cornerStyle: StandardWindow basicNew preferredCornerStyle))
		hResizing: #shrinkWrap;
		cornerStyle: StandardWindow basicNew preferredCornerStyle