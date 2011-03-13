morphicDirectoryTreePane

	^(SimpleHierarchicalListMorph 
		on: self
		list: #initialDirectoryList
		selected: #getSelectedDirectory
		changeSelected: #setSelectedDirectoryTo:
		menu: nil
		keystroke: nil) autoDeselect: false
		
