asPrototypeInWindow
	"Create a pluggable version of me, answer a window"

	| window aTextMorph |
	window _ (SystemWindow labelled: 'later') model: self.
	window
		addMorph: ((PluggableListMorph
				on: self
				list: #processNameList
				selected: #processListIndex
				changeSelected: #processListIndex:
				menu: #processListMenu:
				keystroke: #processListKey:from:)
				enableDragNDrop: false)
		frame: (0 @ 0 extent: 0.5 @ 0.5).
	window
		addMorph: ((PluggableListMorph
				on: self
				list: #stackNameList
				selected: #stackListIndex
				changeSelected: #stackListIndex:
				menu: #stackListMenu:
				keystroke: #stackListKey:from:)
				enableDragNDrop: false)
		frame: (0.5 @ 0.0 extent: 0.5 @ 0.5).
	aTextMorph _ PluggableTextMorph
				on: self
				text: #selectedMethod
				accept: nil
				readSelection: nil
				menu: nil.
	window
		addMorph: aTextMorph
		frame: (0 @ 0.5 corner: 1 @ 1).
	window setLabel: 'Process Browser'.
	^ window