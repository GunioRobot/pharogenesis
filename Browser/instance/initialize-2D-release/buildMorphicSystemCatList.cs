buildMorphicSystemCatList
	| dragNDropFlag myCatList |
	dragNDropFlag _ Preferences browseWithDragNDrop.
	myCatList _ PluggableListMorph on: self list: #systemCategoryList
			selected: #systemCategoryListIndex changeSelected: #systemCategoryListIndex:
			menu: #systemCategoryMenu: keystroke: #systemCatListKey:from:.
	myCatList enableDragNDrop: dragNDropFlag.
	myCatList highlightSelector: #highlightSystemCategoryList:with:.
	^myCatList
