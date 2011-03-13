open
	| window list |
	window _ (SystemWindow labelled: 'Pointer Finder')
		model: self.
	list _ PluggableListMorph new
		doubleClickSelector: #inspectObject;

		on: self
		list: #pointerList
		selected: #pointerListIndex
		changeSelected: #pointerListIndex:
		menu: #menu:shifted:
		keystroke: #arrowKey:from:.
	window addMorph: list frame: (0@0 extent: 1@1).
	list color: Color lightMagenta.
	window openInWorld