buildList
	^ PluggableListMorph
		on: self
		list: #packageList
		selected: #packageSelection
		changeSelected: #packageSelection:
		menu: #packageMenu: