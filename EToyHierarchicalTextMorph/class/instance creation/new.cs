new

	| listMorph model |

	model _ EToyHierarchicalTextGizmo new 
		topNode: EToyTextNode newNode.
	(listMorph _ EToyHierarchicalTextMorph 
		on: model
		list: #getList
		selected: #getCurrentSelection
		changeSelected: #noteNewSelection:
		menu: #genericMenu:
		keystroke: nil).
	listMorph autoDeselect: false.
     ^ listMorph