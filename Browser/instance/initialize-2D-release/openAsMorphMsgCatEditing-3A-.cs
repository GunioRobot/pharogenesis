openAsMorphMsgCatEditing: editString
	"Create a pluggable version a Browser on just a messageCategory."
	| window codePane |
	window _ (SystemWindow labelled: 'later') model: self.

	window addMorph: (PluggableListMorph on: self list: #messageCatListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageCategoryMenu:)
		frame: (0@0 extent: 1.0@0.06).
	window addMorph: (PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:)
		frame: (0@0.06 extent: 1.0@0.30).

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true].
	window addMorph: codePane
		frame: (0@0.36 corner: 1@1).

	^ window