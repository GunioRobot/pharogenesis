buildMorphicMessageList
	"Build my message-list object in morphic"

	| aListMorph |
	aListMorph _ PluggableListMorph new.
	aListMorph
		setProperty: #highlightSelector toValue: #highlightMessageList:with:;
		setProperty: #itemConversionMethod toValue: #asStringOrText;
		setProperty: #balloonTextSelectorForSubMorphs toValue: #balloonTextForClassAndMethodString.
	aListMorph
		on: self list: #messageList
		selected: #messageListIndex changeSelected: #messageListIndex:
		menu: #messageListMenu:shifted:
		keystroke: #messageListKey:from:.
	aListMorph enableDragNDrop: Preferences browseWithDragNDrop.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	^ aListMorph

