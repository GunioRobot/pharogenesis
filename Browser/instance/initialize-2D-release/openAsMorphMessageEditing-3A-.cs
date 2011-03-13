openAsMorphMessageEditing: editString
	"Create a pluggable version a Browser on just a messageCategory."
	| window codePane |
	window _ (SystemWindow labelled: 'later') model: self.

	window addMorph: (PluggableListMorph on: self list: #messageListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageListMenu:shifted:)
		frame: (0@0 extent: 1.0@0.06).

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true].
	window addMorph: codePane
		frame: (0@0.06 corner: 1@1).

	^ window