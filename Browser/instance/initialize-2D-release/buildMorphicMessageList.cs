buildMorphicMessageList

	| aListMorph |

	aListMorph _ PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph enableDragNDrop: Preferences browseWithDragNDrop.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	aListMorph highlightSelector: #highlightMessageList:with:.
	^aListMorph

