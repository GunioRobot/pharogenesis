newPointSizeList 
	| answer |
	answer := PluggableListMorph
		on: self model
		list: #pointSizeList
		selected: #selectedPointSizeIndex
		changeSelected: #selectedPointSizeIndex:.
	answer	
			color: Color white;
			borderInset;
			vResizing: #spaceFill;
			hResizing: #spaceFill;
			yourself.
	^answer