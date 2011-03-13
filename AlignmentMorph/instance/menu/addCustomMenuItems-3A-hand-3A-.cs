addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'orientation...' action: #chooseOrientation.
	aCustomMenu add: (openToDragNDrop ifTrue: ['close'] ifFalse: ['open']) , ' dragNdrop'
			action: #openCloseDragNDrop.
