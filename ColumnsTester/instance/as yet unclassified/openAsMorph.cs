openAsMorph
	| window |
	window _ (SystemWindow labelled: 'Columns Tester')
				model: self.
	listMorph _ PluggableMultiColumnListMorph
				on: self
				list: #listArray
				selected: #mainListIndex
				changeSelected: #mainListIndex:
				menu: #listMenu:.
	window
		addMorph: (listMorph
				autoDeselect: false)
		frame: (0 @ 0 corner: 1.0 @ 1.0).
	window openInWorld