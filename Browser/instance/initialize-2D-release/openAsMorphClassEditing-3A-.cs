openAsMorphClassEditing: editString
	"Create a pluggable version a Browser on just a single class."
	| window dragNDropFlag hSepFrac switchHeight mySingletonClassList |

	window _ (SystemWindow labelled: 'later') model: self.
	dragNDropFlag _ Preferences browseWithDragNDrop.
	hSepFrac _ 0.3.
	switchHeight _ 25.
	mySingletonClassList _ PluggableListMorph on: self list: #classListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #classListMenu:shifted: keystroke: #classListKey:from:.
	mySingletonClassList enableDragNDrop: dragNDropFlag.
	window 
		addMorph: mySingletonClassList
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 0.5@0) 
				offsets: (0@0 corner: 0@switchHeight)
		).
	
	self 
		addMorphicSwitchesTo: window 
		at: (
			LayoutFrame 
				fractions: (0.5@0 corner: 1.0@0) 
				offsets: (0@0 corner: 0@switchHeight)
		).

	window 
		addMorph: self buildMorphicMessageCatList
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 0.5@hSepFrac) 
				offsets: (0@switchHeight corner: 0@0)
		).

	window 
		addMorph: self buildMorphicMessageList
		fullFrame: (
			LayoutFrame 
				fractions: (0.5@0 corner: 1.0@hSepFrac) 
				offsets: (0@switchHeight corner: 0@0)
		).

	self 
		addLowerPanesTo: window 
		at: (0@hSepFrac corner: 1@1) 
		with: editString.
	window setUpdatablePanesFrom: #(messageCategoryList messageList).
	^ window