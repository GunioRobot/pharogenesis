buildMorphicCategoriesList
	"Create the hierarchical list holding the category tree."

	| list |
	list := (SimpleHierarchicalListMorph 
		on: self
		list: #categoryWrapperList
		selected: #selectedCategoryWrapper
		changeSelected: #selectedCategoryWrapper:
		menu: #categoriesMenu:
		keystroke: nil)
		autoDeselect: true;
		enableDrag: false;
		enableDrop: true;
		yourself.
	list setBalloonText: 'The categories are structured in a tree. Packages and package releases belong to several categories.
You can add one or more categories as filters and enable them in the menu.'.
"	list scroller submorphs do:[:each| list expandAll: each]."
	list adjustSubmorphPositions.
	^list