buildMorphicClassList

	| myClassList |

	(myClassList := PluggableListMorph new) 
			setProperty: #highlightSelector toValue: #highlightClassList:with:;

			on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu:shifted: keystroke: #classListKey:from:.
	myClassList borderWidth: 0.
	myClassList enableDragNDrop: Preferences browseWithDragNDrop.
	myClassList doubleClickSelector: #browseSelectionInPlace.
	"For doubleClick to work best disable autoDeselect"
	myClassList autoDeselect: false .
	^myClassList

