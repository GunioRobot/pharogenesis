workingCopyListMorph
	^ PluggableMultiColumnListMorph
		on: self
		list: #workingCopyList
		selected: #workingCopySelection
		changeSelected: #workingCopySelection:
		menu: #workingCopyListMenu: