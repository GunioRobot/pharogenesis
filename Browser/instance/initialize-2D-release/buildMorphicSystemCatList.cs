buildMorphicSystemCatList
	| dragNDropFlag myCatList |
	dragNDropFlag _ Preferences browseWithDragNDrop.
	(myCatList _ PluggableListMorph new) 
			setProperty: #highlightSelector toValue: #highlightSystemCategoryList:with:;

			on: self list: #systemCategoryList
			selected: #systemCategoryListIndex changeSelected: #systemCategoryListIndex:
			menu: #systemCategoryMenu: keystroke: #systemCatListKey:from:.
	myCatList enableDragNDrop: dragNDropFlag.
	^myCatList
