openAsMorph: aChangeList name: labelString multiSelect: multiSelect
	"Open a morphic view for the messageSet, whose label is labelString.
	The listView may be either single or multiple selection type"
	| window listView textMorph |
	window _ (SystemWindow labelled: labelString) model: aChangeList.

	window addMorph: (listView _ PluggableListMorph on: aChangeList list: #list
		selected: #listIndex changeSelected: #toggleListIndex:
		menu: #changeListMenu: keystroke: #messageListKey:from:)
		frame: (0@0 corner: 1@0.3).
"
	multiSelect ifTrue: [listView controller: PluggableListControllerOfMany new].
"
	window addMorph: (textMorph _ PluggableTextMorph on: aChangeList 
			text: #contents accept: #contents:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.3 corner: 1@1).
"
	textMorph controller: ReadOnlyTextController new.
"
	^ window openInWorld