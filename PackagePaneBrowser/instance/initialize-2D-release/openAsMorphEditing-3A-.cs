openAsMorphEditing: editString 
	"Create a pluggable version of all the views for a Browser, including 
	views and controllers."
	"PackagePaneBrowser openBrowser"

	| listHeight window |
	listHeight _ 0.4.
	(window _ SystemWindow labelled: 'later') model: self.
	window
		addMorph: (PluggableListMorph
				on: self
				list: #packageList
				selected: #packageListIndex
				changeSelected: #packageListIndex:
				menu: #packageMenu:
				keystroke: #packageListKey:from:)
		frame: (0 @ 0 extent: 0.15 @ listHeight).
	window
		addMorph: self buildMorphicSystemCatList
		frame: (0.15 @ 0 extent: 0.2 @ listHeight).
	self
		addClassAndSwitchesTo: window
		at: (0.35 @ 0 extent: 0.25 @ listHeight)
		plus: 0.
	window
		addMorph: self buildMorphicMessageCatList
		frame: (0.6 @ 0 extent: 0.15 @ listHeight).
	window
		addMorph: self buildMorphicMessageList
		frame: (0.75 @ 0 extent: 0.25 @ listHeight).
	self
		addLowerPanesTo: window
		at: (0 @ listHeight corner: 1 @ 1)
		with: editString.
	window setUpdatablePanesFrom: #(#packageList #systemCategoryList #classList #messageCategoryList #messageList ).
	^ window