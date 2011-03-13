buildMorphicMessageCatList

	| myMessageCatList |
	myMessageCatList _ PluggableMessageCategoryListMorph on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu: 
			keystroke: #arrowKey:from: getRawListSelector: #rawMessageCategoryList.
	myMessageCatList enableDragNDrop: Preferences browseWithDragNDrop.
	myMessageCatList highlightSelector: #highlightMessageCategoryList:with:.
	^myMessageCatList
