newCategoryPane
	"Formulate a category pane for insertion into the receiver's pane list"

	| aListMorph |
	aListMorph _ PluggableListMorph on: self list: #categoryList
			selected: #categoryListIndex changeSelected: #categoryListIndex:
			menu: #categoryListMenu:shifted:
			keystroke: #categoryListKey:from:.
	aListMorph setNameTo: 'categoryList'.
	aListMorph menuTitleSelector: #categoryListMenuTitle.
	^ aListMorph