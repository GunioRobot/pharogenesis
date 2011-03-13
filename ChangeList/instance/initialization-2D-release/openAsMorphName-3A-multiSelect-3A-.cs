openAsMorphName: labelString multiSelect: multiSelect
	"Open a morphic view for the messageSet, whose label is labelString.
	The listView may be either single or multiple selection type"

	| window listHeight listPane |
	listHeight _ 0.4.

	window _ (SystemWindow labelled: labelString)
		model: self.

	listPane _ (multiSelect
				ifTrue: [PluggableListMorphOfMany]
				ifFalse: [PluggableListMorph])
			on: self
			list: #list
			selected: #listIndex
			changeSelected: #toggleListIndex:
			menu: (self showsVersions
				ifTrue: [#versionsMenu:]
				ifFalse: [#changeListMenu:]).
	listPane keystrokeActionSelector: #changeListKey:from:.
	window addMorph: listPane
		frame: (0 @ 0 extent: 1 @ listHeight).

	self 
		addLowerPanesTo: window 
		at: (0@listHeight corner: 1@1) 
		with: nil.

	^ window openInWorld