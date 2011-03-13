buildMorphicClassList

	| myClassList |

	myClassList _ PluggableListMorph on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu:shifted: keystroke: #classListKey:from:.
	myClassList borderWidth: 0.
	myClassList enableDragNDrop: Preferences browseWithDragNDrop.
	myClassList highlightSelector: #highlightClassList:with:.
	^myClassList

