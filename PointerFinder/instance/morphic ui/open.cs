open
	| window list |
	window _ (SystemWindow labelled: 'Pointer Finder')
		model: self.
	list _ PluggableListMorph
			on: self
			list: #pointerList
			selected: #pointerListIndex
			changeSelected: #pointerListIndex:
			menu: #menu:shifted:.
	list doubleClickSelector: #inspectObject.
	window addMorph: list frame: (0@0 extent: 1@1).
	list color: Color lightMagenta.
	window openInWorld