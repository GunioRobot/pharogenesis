acceptDroppingMorph: aMorph event: evt
	| slotSpecs aValue incomingName nameObtained mm tfm |

	self isWorldMorph
		ifTrue:
			["Add the given morph to this world and start stepping it if it wants to be."
			self addMorphFront: aMorph.
			(aMorph fullBounds intersects: ("0@0 extent:" self viewBox "extent")) ifFalse:
				[self beep.  aMorph position: self bounds center]]
		ifFalse:
			[self privateAddMorph: aMorph atIndex: (self insertionIndexFor: aMorph).
			self changed.
			self layoutChanged].

	incomingName _ aMorph knownName.
	aMorph submorphsDo: [:m | (m isKindOf: HaloMorph) ifTrue: [m delete]].
	self autoLineLayout ifTrue: [self fixLayout].
	aMorph allMorphsDo:  "Establish any penDown morphs in new world"
		[:m | m player ifNotNil:
			[m player getPenDown ifTrue:
				[((mm _ m player costume) notNil and: [(tfm _ mm owner transformFrom: self) notNil])
					ifTrue: [self noteNewLocation: (tfm localPointToGlobal: mm referencePosition)
									forPlayer: m player]]]].

	self isPartsBin
		ifTrue:
			[aMorph isPartsDonor: true.
			aMorph stopSteppingSelfAndSubmorphs.
			aMorph suspendEventHandler]
		ifFalse:
			[self world startSteppingSubmorphsOf: aMorph].

	self presenter morph: aMorph droppedIntoPasteUpMorph: self.

	slotSpecs _ aMorph slotSpecifications.  "A Fabrik component, for example.  Just a hook at this time"
	slotSpecs size > 0 ifTrue:
		[self assuredPlayer.
		slotSpecs do:
			[:tuple |
				aValue _ aMorph initialValueFor: tuple first.
				nameObtained _ self player addSlotNamedLike: tuple first withValue: aValue.
				nameObtained ~= incomingName ifTrue:
					[aMorph setNameTo: nameObtained]].
		self player updateAllViewers]