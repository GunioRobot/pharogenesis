openAsMorphSysCatEditing: editString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| window codePane |
	window _ (SystemWindow labelled: 'later') model: self.

	window addMorph: (PluggableListMorph on: self list: #systemCategorySingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #systemCategoryMenu:)
		frame: (0@0 extent: 1.0@0.06).
	window addMorph: (PluggableListMorph on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu:)
		frame: (0@0.06 extent: 0.3333@0.24).
	window addMorph: self buildMorphicSwitches
		frame: (0@0.3 extent: 0.3333@0.06).
	window addMorph: (PluggableListMorph on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu:)
		frame: (0.3333@0.06 extent: 0.3333@0.30).
	window addMorph: (PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:)
		frame: (0.6666@0.06 extent: 0.3333@0.30).

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true].
	window addMorph: codePane
		frame: (0@0.36 corner: 1@1).

	^ window