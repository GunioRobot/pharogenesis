explorerFor: anObject
	| window listMorph |
	rootObject _ anObject.
	window _ (SystemWindow labelled: self label) model: self.
	window addMorph: (listMorph _ SimpleHierarchicalListMorph 
			on: self
			list: #getList
			selected: #getCurrentSelection
			changeSelected: #noteNewSelection:
			menu: #genericMenu:
			keystroke: #explorerKey:from:)
		frame: (0@0 corner: 1@0.8).
	window addMorph: ((PluggableTextMorph on: self text: #trash accept: #trash:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
					askBeforeDiscardingEdits: false)
		frame: (0@0.8 corner: 1@1).
	listMorph autoDeselect: false.
     ^ window