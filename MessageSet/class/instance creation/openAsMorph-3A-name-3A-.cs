openAsMorph: aMessageSet name: labelString 
	"Create a SystemWindow aMessageSet, with the label labelString."
	| window |
	window _ (SystemWindow labelled: labelString) model: aMessageSet.
	window addMorph: (PluggableListMorph on: aMessageSet list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:)
		frame: (0@0 extent: 1@0.2).

	window addMorph: (PluggableTextMorph on: aMessageSet 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.2 corner: 1@1).

	window openInWorld