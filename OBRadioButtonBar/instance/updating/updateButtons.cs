updateButtons
	| labels |
	labels := model perform: getListSelector.
	buttons := Array new: labels size.
	labels withIndexDo: 
			[:label :index | 
			buttons at: index put: (OBButtonModel withLabel: label inBar: self)].
	selection := self getSelectionIndex