addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'orientation...' action: #chooseOrientation.
	aCustomMenu add: (self dragNDropEnabled ifTrue: ['close'] ifFalse: ['open']) , ' dragNdrop'
			action: #toggleDragNDrop.
