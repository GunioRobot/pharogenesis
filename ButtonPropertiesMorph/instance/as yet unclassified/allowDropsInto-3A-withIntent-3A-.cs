allowDropsInto: aMorph withIntent: aSymbol

	aMorph
		on: #mouseEnterDragging send: #mouseEnterDraggingEvt:morph: to: self;
		on: #mouseLeaveDragging send: #mouseLeaveDraggingEvt:morph: to: self;
		on: #mouseLeave send: #clearDropHighlightingEvt:morph: to: self;
		setProperty: #handlerForDrops toValue: self;
		setProperty: #intentOfDroppedMorphs toValue: aSymbol;
		borderWidth: 1;
		borderColor: Color gray
