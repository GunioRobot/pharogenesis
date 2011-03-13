buildMorphicMessageList
	"Build a morphic message list, with #messageList as its list-getter"

	| aListMorph |
	(aListMorph := PluggableListMorph new) 
			setProperty: #highlightSelector toValue: #highlightMessageList:with:;
			setProperty: #balloonTextSelectorForSubMorphs toValue: #balloonTextForMethodString;
			on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph enableDragNDrop: Preferences browseWithDragNDrop.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	^aListMorph

