step
	| hand insertion i space1 d space2 insHt nxtHt prevBot ht2 c1 c2 ii |
	hand _ handWithTile ifNil: [self primaryHand].
	(hand lastEvent redButtonPressed)
		ifTrue:
		[hand submorphCount > 0 ifTrue:
			[insertion _ hand firstSubmorph.
			insHt _ insertion height.
			self removeSpaces.
			i _ (ii _ self indexOfMorphAbove: insertion fullBounds topLeft)
					min: submorphs size-1.
			prevBot _ i <= 0 ifTrue: [(self innerBounds) top]
					ifFalse: [(self submorphs at: i) bottom].
			nxtHt _ (submorphs isEmpty
					ifTrue: [insertion]
					ifFalse: [self submorphs at: i+1]) height.
			d _ ii > i ifTrue: [nxtHt "for consistent behavior at bottom"]
					ifFalse: [0 max: (insertion top - prevBot min: nxtHt)].

			"Top and bottom spacer heights cause continuous motion..."
			c1 _ Color green.  c2 _ Color transparent.
			ht2 _ d*insHt//nxtHt.
			space1 _ Morph newBounds: (0@0 extent: 30@(insHt-ht2))
					color: ((insHt-ht2) > (insHt//2+1) ifTrue: [c1] ifFalse: [c2]).
			self privateAddMorph: space1 atIndex: (i+1 max: 1).
			space2 _ Morph newBounds: (0@0 extent: 30@ht2)
					color: (ht2 > (insHt//2+1) ifTrue: [c1] ifFalse: [c2]).
			self privateAddMorph: space2 atIndex: (i+3 min: submorphs size+1)]]
		ifFalse:
		[self stopStepping.
		self removeSpaces.
		self allMorphsDo: [:m |
			(m isKindOf: TileMorph) ifTrue: [
				m color: (ScriptingSystem unbrightColorFor: m color)]]]