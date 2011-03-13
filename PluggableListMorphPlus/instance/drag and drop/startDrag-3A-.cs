startDrag: evt 
	| ddm draggedItem dragIndex |
	dragItemSelector ifNil:[^self].
	evt hand hasSubmorphs ifTrue: [^ self].
	[(self dragEnabled and: [model okToChange]) ifFalse: [^ self].
	dragIndex := self rowAtLocation: evt position.
	dragIndex = 0 ifTrue:[^self].
	draggedItem := model perform: dragItemSelector with: dragIndex.
	draggedItem ifNil:[^self].
	ddm := TransferMorph withPassenger: draggedItem from: self.
	ddm dragTransferType: #dragTransferPlus.
	evt hand grabMorph: ddm]
		ensure: [Cursor normal show.
			evt hand releaseMouseFocus: self]