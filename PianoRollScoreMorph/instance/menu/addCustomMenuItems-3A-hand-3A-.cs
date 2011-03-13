addCustomMenuItems: aMenu hand: aHandMorph

	super addCustomMenuItems: aMenu hand: aHandMorph.
	aMenu add: 'expand time' action: #expandTime.
	aMenu add: 'contract time' action: #contractTime.
	aMenu addLine.
	aMenu add: 'add movie clip player' action: #addMovieClipPlayer.
	(self valueOfProperty: #dragNDropEnabled) == true
		ifTrue: [aMenu add: 'close drag and drop' action: #disableDragNDrop]
		ifFalse: [aMenu add: 'open drag and drop' action: #enableDragNDrop].
