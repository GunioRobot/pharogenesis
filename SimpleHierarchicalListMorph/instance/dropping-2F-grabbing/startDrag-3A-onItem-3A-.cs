startDrag: evt onItem: itemMorph 
	| ddm |
	evt hand hasSubmorphs
		ifTrue: [^self].

	itemMorph ~= self selectedMorph ifTrue: [self setSelectedMorph: itemMorph].
	ddm _ TransferMorph withPassenger: (self model dragPassengerFor: itemMorph inMorph: self) from: self.
	ddm dragTransferType: (self model dragTransferTypeForMorph: self).
	Preferences dragNDropWithAnimation
			ifTrue: [self model dragAnimationFor: itemMorph transferMorph: ddm].
	evt hand grabMorph: ddm