trackDropZones
	"The fundamental heart of script-editor layout, by Dan Ingalls in fall 1997, though many hands have touched it since."

	| hand insertion i space1 d space2 insHt nxtHt prevBot ht2 c1 c2 ii where |
	hand _ handWithTile ifNil: [self primaryHand].
	((self hasOwner: hand) not and: [hand submorphCount > 0])
		ifTrue:
			[insertion _ hand firstSubmorph renderedMorph.
			insHt _ insertion fullBounds height.			self removeSpaces.
			where _ self globalPointToLocal: hand position"insertion fullBounds topLeft".
			i _ (ii _ self indexOfMorphAbove: where) min: submorphs size-1.
			prevBot _ i <= 0 ifTrue: [(self innerBounds) top]
							ifFalse: [(self submorphs at: i) bottom].
			nxtHt _ (submorphs isEmpty
				ifTrue: [insertion]
				ifFalse: [self submorphs at: i+1]) height.
			d _ ii > i ifTrue: [nxtHt "for consistent behavior at bottom"]
					ifFalse: [0 max: (where y - prevBot min: nxtHt)].

			"Top and bottom spacer heights cause continuous motion..."
			c1 _ Color green.  c2 _ Color transparent.
			ht2 _ d*insHt//nxtHt.
			space1 _ Morph newBounds: (0@0 extent: 30@(insHt-ht2))
                                        color: ((insHt-ht2) > (insHt//2+1) ifTrue: [c1] ifFalse: [c2]).
			self privateAddMorph: space1 atIndex: (i+1 max: 1).
			space2 _ Morph newBounds: (0@0 extent: 30@ht2)
                                        color: (ht2 > (insHt//2+1) ifTrue: [c1] ifFalse: [c2]).
			self privateAddMorph: space2 atIndex: (i+3 min: submorphs size+1)]
		ifFalse:
			[self stopSteppingSelector: #trackDropZones.
			self removeSpaces]