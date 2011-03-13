openAsMorphMsgCatEditing: editString
	"Create a pluggable version a Browser on just a message category."

	| window hSepFrac |
	window _ (SystemWindow labelled: 'later') model: self.
	hSepFrac _ 0.3.
	window 
		addMorph: ((PluggableListMorph on: self list: #messageCatListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageCategoryMenu:) enableDragNDrop: Preferences browseWithDragNDrop)
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 1@0) 
				offsets: (0@0 corner: 0@25)
		).
	window 
		addMorph: self buildMorphicMessageList
		fullFrame: (
			LayoutFrame 
				fractions: (0@0 corner: 1@hSepFrac) 
				offsets: (0@25 corner: 0@0)
		).

	self 
		addLowerPanesTo: window 
		at: (0@hSepFrac corner: 1@1) 
		with: editString.
	window setUpdatablePanesFrom: #(messageCatListSingleton messageList).
	^ window