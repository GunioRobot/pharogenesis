openAsMorphMessageEditing: editString
	"Create a pluggable version a Browser that shows just one message"
	| window codePane baseline aTextMorph |
	window _ (SystemWindow labelled: 'later') model: self.

	window addMorph: ((PluggableListMorph on: self list: #messageListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:) enableDragNDrop: Preferences browseWithDragNDrop)
		frame: (0@0 extent: 1.0@0.06).

	Preferences useAnnotationPanes
		ifFalse:
			[baseline _ 0.06]
		ifTrue:
			[aTextMorph _ PluggableTextMorph on: self
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.06 corner: 1@0.11).
			baseline _ 0.11].

	Preferences optionalButtons
		ifTrue:
			[window addMorph: self optionalButtonRow frame: ((0@baseline corner: 1 @ (baseline + 0.08))).
			baseline _ baseline + 0.08].

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true].
	window addMorph: codePane
		frame: (0@baseline corner: 1@1).

	^ window