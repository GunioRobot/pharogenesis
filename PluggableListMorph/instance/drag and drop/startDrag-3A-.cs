startDrag: evt 
	| ddm draggedItem draggedItemMorph passenger |
	evt hand hasSubmorphs
		ifTrue: [^ self].
	[(self dragEnabled
			and: [model okToChange])
		ifFalse: [^ self].
	(draggedItem := self selection)
		ifNil: [^ self].
	draggedItemMorph := StringMorph contents: draggedItem asStringOrText.
	passenger := self model dragPassengerFor: draggedItemMorph inMorph: self.
	passenger
		ifNil: [^ self].
	ddm := TransferMorph withPassenger: passenger from: self.
	ddm
		dragTransferType: (self model dragTransferTypeForMorph: self).
	Preferences dragNDropWithAnimation
		ifTrue: [self model dragAnimationFor: draggedItemMorph transferMorph: ddm].
	evt hand grabMorph: ddm]
		ensure: [Cursor normal show.
			evt hand releaseMouseFocus: self]