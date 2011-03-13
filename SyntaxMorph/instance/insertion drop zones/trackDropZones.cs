trackDropZones
	| hand i localPt insertion insHt ii prevBot nxtHt d c1 c2 ht2 spacer1 spacer2 wid ht1 |
	hand _ self primaryHand.
	(hand lastEvent redButtonPressed & hand hasSubmorphs
		and: [(self hasOwner: hand) not]) ifFalse: [^ self].

	insertion _ hand firstSubmorph renderedMorph.
	insertion isNoun ifFalse: [^ self].
	localPt _ self globalPointToLocal: hand position.
	insHt _ insertion height.  "**just use standard line height here"
	self removeDropZones.  "Maybe first check if in right place, then just tweak heights."
	i _ (ii _ self indexOfMorphAbove: localPt) min: submorphs size-1.
	prevBot _ i <= 0 ifTrue: [(self innerBounds) top]
					ifFalse: [(self submorphs at: i) bottom].
	nxtHt _ (submorphs isEmpty
		ifTrue: [insertion]
		ifFalse: [self submorphs at: i+1]) height.
	d _ ii > i ifTrue: [nxtHt "for consistent behavior at bottom"]
			ifFalse: [0 max: (localPt y - prevBot min: nxtHt)].

	"Top and bottom spacer heights cause continuous motion..."
	c1 _ Color yellow lighter.  c2 _ Color transparent.
	ht2 _ d*insHt//nxtHt.  ht1 _ insHt - ht2.
	wid _ 100 min: owner width - 10.
	(spacer1 _ BorderedMorph newBounds: (0@0 extent: wid@ht1)
					color: (ht1 > (insHt//2) ifTrue: [c1] ifFalse: [c2]))
					borderWidth: 1; borderColor: spacer1 color.
	self privateAddMorph: spacer1 atIndex: (i+1 max: 1).
	(spacer2 _ BorderedMorph newBounds: (0@0 extent: wid@ht2)
					color: (ht2 > (insHt//2+1) ifTrue: [c1] ifFalse: [c2]))
					borderWidth: 1; borderColor: spacer2 color.
	self privateAddMorph: spacer2 atIndex: (i+3 min: submorphs size+1).
	self fullBounds.  "Force layout prior to testing for cursor containment"

	"Maintain the drop target highlight -- highlight spacer if hand is in it."
	{spacer1. spacer2} do:
		[:spacer | (spacer containsPoint: localPt) ifTrue:
			[spacer borderColor: self dropColor.
			self borderColor = self dropColor
				ifTrue: [self borderColor: self stdBorderColor]]].
	"If no submorph (incl spacers) highlighted, then re-highlight the block."
	((self wantsDroppedMorph: insertion event: hand lastEvent) and:
		[(self submorphs anySatisfy: [:m | m containsPoint: localPt]) not])
		ifTrue: [self borderColor: self dropColor]
