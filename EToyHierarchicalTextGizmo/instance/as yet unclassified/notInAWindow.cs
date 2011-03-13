notInAWindow
	| listMorph |

	(listMorph _ EToyHierarchicalTextMorph 
		on: self
		list: #getList
		selected: #getCurrentSelection
		changeSelected: #noteNewSelection:
		menu: #genericMenu:
		keystroke: nil).
	listMorph autoDeselect: false.
     ^ listMorph