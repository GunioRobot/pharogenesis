phraseForSlot: slotName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector
	"Return a PhraseTileMorph representing the slot in the viewer"

	| r anArrow |
	r _ ViewerRow newRow
		color: self color;
		beSticky;
		elementSymbol: slotName asSymbol;
		centering: #center.

	r addMorphBack: (self slotHeaderFor: slotName).
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"

	r addMorphBack: (self infoButtonFor: slotName).
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"

	r addMorphBack: self tileForSelf bePossessive.
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
	r addMorphBack: (self getterButtonFor: slotName type: partType).

	(slotName == #isOverColor)
		ifTrue:
			[self addIsOverColorDetailTo: r]
		ifFalse:
			[readOnly ifFalse:
				[r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
				r addMorphBack: (anArrow _ self arrowSetterButtonFor: slotName type: partType)].
			r addMorphBack: (AlignmentMorph new beTransparent).  "flexible spacer"
			(#(colorSees) includes: slotName) ifFalse:
		 		[r addMorphBack: (self readoutFor: slotName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector)]].
	anArrow ifNotNil: [anArrow step].
	^ r