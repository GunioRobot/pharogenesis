openAsMorph: aChangeList name: labelString multiSelect: multiSelect
	"Open a morphic view for the messageSet, whose label is labelString.
	The listView may be either single or multiple selection type"
	| window boundary  |
	window _ (SystemWindow labelled: labelString) model: aChangeList.
	Preferences optionalButtons
		ifFalse:
			[boundary _ 0]
		ifTrue:
			[boundary _ 0.08.
			window addMorph: aChangeList buttonRowForChangeList frame: (0 @ 0 corner: 1 @ boundary)].

	window addMorph: ((multiSelect ifTrue: [PluggableListMorphOfMany]
									ifFalse: [PluggableListMorph])
		on: aChangeList list: #list
		selected: #listIndex changeSelected: #toggleListIndex:
		menu: (aChangeList showsVersions ifTrue: [#versionsMenu:] ifFalse: [#changeListMenu:])
			keystroke: nil)
		frame: (0@boundary corner: 1@0.4).

	window addMorph: (AcceptableCleanTextMorph on: aChangeList 
			text: #contents accept: #contents:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (0@0.4 corner: 1@1).
	^ window openInWorld