openAsMorphEditing: editString
	"Create a pluggable version of all the morphs for a Browser in Morphic"
	| window switches codePane aListMorph baseline aTextMorph dragNDropFlag |
	window _ (SystemWindow labelled: 'later') model: self.

	dragNDropFlag _ Preferences browseWithDragNDrop.
	window addMorph: ((PluggableListMorph on: self list: #systemCategoryList
			selected: #systemCategoryListIndex changeSelected: #systemCategoryListIndex:
			menu: #systemCategoryMenu: keystroke: #systemCatListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0@0 extent: 0.25@0.4).
	window addMorph: ((PluggableListMorph on: self list: #classList
			selected: #classListIndex changeSelected: #classListIndex:
			menu: #classListMenu: keystroke: #classListKey:from:) enableDragNDrop: dragNDropFlag)
		frame: (0.25@0 extent: 0.25@0.3).
	switches _ self buildMorphicSwitches.
	window addMorph: switches frame: (0.25@0.3 extent: 0.25@0.1).
	switches borderWidth: 0.
	window addMorph: ((PluggableMessageCategoryListMorph on: self list: #messageCategoryList
			selected: #messageCategoryListIndex changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu: keystroke: #arrowKey:from: getRawListSelector: #rawMessageCategoryList) enableDragNDrop: dragNDropFlag)
		frame: (0.5@0 extent: 0.25@0.4).
	aListMorph _ PluggableListMorph on: self list: #messageList
			selected: #messageListIndex changeSelected: #messageListIndex:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph enableDragNDrop: dragNDropFlag.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph
		frame: (0.75@0 extent: 0.25@0.4).

	Preferences useAnnotationPanes
		ifFalse:
			[baseline _ 0.4]
		ifTrue:
			[aTextMorph _ PluggableTextMorph on: self
					text: #annotation accept: nil
					readSelection: nil menu: nil.
			aTextMorph askBeforeDiscardingEdits: false.
			window addMorph: aTextMorph
				frame: (0@0.4 corner: 1@0.45).
			baseline _ 0.45].

	Preferences optionalButtons
		ifTrue:
			[window addMorph: self optionalButtonRow frame: ((0@baseline corner: 1 @ (baseline + 0.08))).
			baseline _ baseline + 0.08].

	codePane _ PluggableTextMorph on: self text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true].
	window addMorph: codePane
		frame: (0 @ baseline corner: 1 @ 1).

	window setUpdatablePanesFrom: #(systemCategoryList classList messageCategoryList messageList).
	^ window