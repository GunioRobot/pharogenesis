buildMorphicClassList

	| myClassList |

	(myClassList _ PluggableListMorph new) 
			setProperty: #highlightSelector toValue: #highlightClassList:with:;

			on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu:shifted: keystroke: #classListKey:from:.
	myClassList borderWidth: 0.
	myClassList enableDragNDrop: Preferences browseWithDragNDrop.
	myClassList doubleClickSelector: #browseSelectionInPlace.
	^myClassList

