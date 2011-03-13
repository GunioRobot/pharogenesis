openAsMorphMessageEditing: editString
	"Create a pluggable version a Browser that shows just one message"
	| window mySingletonMessageList verticalOffset nominalFractions |
	window _ (SystemWindow labelled: 'later') model: self.

	mySingletonMessageList _ PluggableListMorph on: self list: #messageListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageListMenu:shifted:
			keystroke: #messageListKey:from:.
	mySingletonMessageList enableDragNDrop: Preferences browseWithDragNDrop.
	verticalOffset _ 25.
	nominalFractions _ 0@0 corner: 1@0.
	window 
		addMorph: mySingletonMessageList
		fullFrame: (
			LayoutFrame 
				fractions: nominalFractions 
				offsets: (0@0 corner: 0@verticalOffset)
		).

	verticalOffset _ self addOptionalAnnotationsTo: window at: nominalFractions plus: verticalOffset.
	verticalOffset _ self addOptionalButtonsTo: window  at: nominalFractions plus: verticalOffset.

	window 
		addMorph: (self buildMorphicCodePaneWith: editString)
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 1@1) 
				offsets: (0@verticalOffset corner: 0@0)
		).

	^ window