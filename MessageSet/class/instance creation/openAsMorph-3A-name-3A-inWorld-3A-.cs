openAsMorph: aMessageSet name: labelString inWorld: aWorld
	"Create a SystemWindow aMessageSet, with the label labelString."
	| window aListMorph aTextMorph baseline |
	window _ (SystemWindow labelled: labelString) model: aMessageSet.
	aListMorph _ PluggableListMorph on: aMessageSet list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph frame: (0@0 extent: 1@0.2).

	Preferences useAnnotationPanes
		ifFalse:
			[baseline  _ 0.2]
		ifTrue:
			[aTextMorph _ PluggableTextMorph on: aMessageSet
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.2 corner: 1@0.25).
			baseline _ 0.25].
	Preferences optionalButtons
		ifTrue:
			[window addMorph: aMessageSet optionalButtonRow frame: ((0@baseline corner: 1 @ (baseline + 0.08))).
			baseline _ baseline + 0.08].

	window addMorph: (PluggableTextMorph on: aMessageSet 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@baseline corner: 1@1).

		window setUpdatablePanesFrom: #(messageList).
	window openInWorld: aWorld