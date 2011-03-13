acceptDroppingMorph: aMorph event: evt
	| slotSpecs aValue incomingName nameObtained |
	aMorph submorphsDo: [:m | (m isKindOf: HaloMorph) ifTrue: [m delete]].
	self privateAddMorph: aMorph atIndex: (self insertionIndexFor: aMorph).
	incomingName _ aMorph knownName.
	self changed.
	self layoutChanged.
	self autoLineLayout ifTrue: [self fixLayout].
	self world startSteppingSubmorphsOf: aMorph.
	self presenter morph: aMorph droppedIntoPasteUpMorph: self.

	slotSpecs _ aMorph slotSpecifications.  "A Fabrik component, for example.  Just a hook at this time"
	slotSpecs size > 0 ifTrue:
		[self assuredCostumee.
		slotSpecs do:
			[:tuple |
				aValue _ aMorph initialValueFor: tuple first.
				nameObtained _ costumee addSlotNamedLike: tuple first withValue: aValue.
				nameObtained ~= incomingName ifTrue:
					[aMorph setNameTo: nameObtained]].
		costumee updateAllViewers]