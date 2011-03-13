setOtherSelection: otherOrNil

	otherSelection _ otherOrNil.
	otherOrNil == nil
		ifTrue: [super borderColor: Color blue]
		ifFalse: [itemsAlreadySelected _ otherSelection selectedItems.
				super borderColor: Color green]