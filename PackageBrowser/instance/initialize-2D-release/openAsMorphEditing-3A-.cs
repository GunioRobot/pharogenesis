openAsMorphEditing: editString 
	"Create a pluggable version of all the views for a Browser, including    
	views and controllers."
	"PackageBrowser openBrowser"
	| listHeight buttonHeight window switches codePane aListMorph dragNDropFlag |
	listHeight _ 0.33.
	buttonHeight _ 0.09.
	window _ (SystemWindow labelled: 'later')
				model: self.
	dragNDropFlag _ Preferences browseWithDragNDrop.
	window addMorph: (PluggableListMorph
			on: self
			list: #packageList
			selected: #packageListIndex
			changeSelected: #packageListIndex:
			menu: #packageMenu:
			keystroke: #packageListKey:from:)
		frame: (0 @ 0 extent: 0.15 @ listHeight).
	window addMorph: ((PluggableListMorph
			on: self
			list: #systemCategoryList
			selected: #systemCategoryListIndex
			changeSelected: #systemCategoryListIndex:
			menu: #systemCategoryMenu:
			keystroke: #systemCatListKey:from:)
			enableDrag: false;
			enableDrop: dragNDropFlag)
		frame: (0.15 @ 0 extent: 0.2 @ listHeight).
	window addMorph: ((PluggableListMorph
			on: self
			list: #classList
			selected: #classListIndex
			changeSelected: #classListIndex:
			menu: #classListMenu:
			keystroke: #classListKey:from:)
			enableDragNDrop: dragNDropFlag)
		frame: (0.35 @ 0 extent: 0.25 @ (listHeight - buttonHeight)).
	switches _ self buildMorphicSwitches.
	window addMorph: switches frame: (0.35 @ (listHeight - buttonHeight) extent: 0.25 @ buttonHeight).
	switches borderWidth: 0.
	window addMorph: ((PluggableListMorph
			on: self
			list: #messageCategoryList
			selected: #messageCategoryListIndex
			changeSelected: #messageCategoryListIndex:
			menu: #messageCategoryMenu:)
			enableDrag: false;
			enableDrop: dragNDropFlag)
		frame: (0.6 @ 0 extent: 0.15 @ listHeight).
	aListMorph _ PluggableListMorph
				on: self
				list: #messageList
				selected: #messageListIndex
				changeSelected: #messageListIndex:
				menu: #messageListMenu:shifted:
				keystroke: #messageListKey:from: .
	aListMorph enableDragNDrop: dragNDropFlag.
	aListMorph menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph frame: (0.75 @ 0 extent: 0.25 @ listHeight).
	codePane _ PluggableTextMorph
				on: self
				text: #contents
				accept: #contents:notifying:
				readSelection: #contentsSelection
				menu: #codePaneMenu:shifted:.
	editString
		ifNotNil: 
			[codePane editString: editString.
			codePane hasUnacceptedEdits: true].
	window addMorph: codePane frame: (0 @ listHeight corner: 1 @ 1).
	window setUpdatablePanesFrom: #(packageList systemCategoryList classList messageCategoryList messageList ).
	^ window