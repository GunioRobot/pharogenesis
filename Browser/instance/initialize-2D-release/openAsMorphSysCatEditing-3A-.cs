openAsMorphSysCatEditing: editString
	"Create a pluggable version of all the views for a Browser, including views and controllers."
	| window switches codePane baseline aTextMorph dragNDropFlag |
	window _ (SystemWindow labelled: 'later') model: self.

	dragNDropFlag _ Preferences browseWithDragNDrop.

	window addMorph: ((PluggableListMorph on: self list: #systemCategorySingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #systemCatSingletonMenu: keystroke: #systemCatSingletonKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0@0 extent: 1.0@0.06).
	window addMorph: ((PluggableListMorph on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu: keystroke: #classListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0@0.06 extent: 0.3333@0.24).
	switches _ self buildMorphicSwitches.
	window addMorph: switches frame: (0@0.3 extent: 0.3333@0.06).
	switches borderWidth: 0.
	window addMorph: ((PluggableMessageCategoryListMorph on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu: keystroke: #arrowKey:from:	 getRawListSelector: #rawMessageCategoryList) enableDragNDrop: dragNDropFlag)
		frame: (0.3333@0.06 extent: 0.3333@0.30).

	window addMorph: ((PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0.6666@0.06 extent: 0.3333@0.30).

	Preferences useAnnotationPanes
		ifFalse: 	[baseline _ 0.36]
		ifTrue: [baseline _ 0.41.
			aTextMorph _ PluggableTextMorph on: self
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.36 corner: 1@baseline)].

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

	window setUpdatablePanesFrom: #( classList messageCategoryList messageList).
	^ window