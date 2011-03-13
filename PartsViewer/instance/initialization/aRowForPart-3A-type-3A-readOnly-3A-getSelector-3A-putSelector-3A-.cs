aRowForPart: partName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector
	"Return a row representing the given part of my target morph."

	| r anArrow |
	r _ AlignmentMorph newRow
		color: self color;
		centering: #center;
		inset: 1.
	r addMorphBack: (self infoButtonFor: partName).
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"

	r addMorphBack: self tileForSelf bePossessive.
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
	r addMorphBack: (self getterButtonFor: partName type: partType).

	readOnly ifFalse:
		[r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
		r addMorphBack: (anArrow _ self arrowSetterButtonFor: partName type: partType)].
	r addMorphBack: (AlignmentMorph new color: self color).  "flexible spacer"
	(#(colorSees) includes: partName) ifFalse:
 		[r addMorphBack: (self readoutFor: partName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector)].
	anArrow ifNotNil: [anArrow step].
	^ r