buildMorphicMessageCatList

	| myMessageCatList |

	(myMessageCatList := PluggableMessageCategoryListMorph new) 
			setProperty: #highlightSelector toValue: #highlightMessageCategoryList:with:;

			on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu: 
			keystroke: #arrowKey:from: getRawListSelector: #rawMessageCategoryList.
	myMessageCatList enableDragNDrop: Preferences browseWithDragNDrop.
	^myMessageCatList
