addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'expand time' action: #expandTime.
	aCustomMenu add: 'contract time' action: #contractTime.
	(self valueOfProperty: #dragNDropEnabled) == true
		ifTrue: [aCustomMenu add: 'close drag and drop' action: #disableDragNDrop]
		ifFalse: [aCustomMenu add: 'open drag and drop' action: #enableDragNDrop].
