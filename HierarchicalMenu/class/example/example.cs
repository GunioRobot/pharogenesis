example  "HierarchicalMenu example"
	^ (HierarchicalMenu
		labelList: #('one' ('two...' 'buckle' 'my' 'shoe') 'three' ('four...' 'close' 'the' 'door'))
		selections: #('one' ('buckle' 'my' 'shoe') 'three' ('close' 'the' 'door')))
		startUpWithCaption: 'Give it a whirl'