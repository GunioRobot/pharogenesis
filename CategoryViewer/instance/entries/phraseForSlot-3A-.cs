phraseForSlot: slotSpec
	"Return a PhraseTileMorph representing a variable belonging to the player"

	"The slot spec if a tuple with the following structure:
		1	#slot
		2	slot name
		3	balloon help
		4	slot type
		5	#readOnly,# readWrite, or #writeOnly
		6	getter receiver indicator
		7	getter selector
		8	setter receiver indicator
		9	setter selector

	NB:	all are symbols except #3, which is a string"

	| r anArrow slotName getterButton ut cover inner |

	r _ ViewerRow newRow
		color: self color;
		beSticky;
		elementSymbol: (slotName _ slotSpec second);
		wrapCentering: #center;
		cellPositioning: #leftCenter.

	r addMorphBack: (self slotHeaderFor: slotName).
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"

	r addMorphBack: (self infoButtonFor: slotName).
	r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"

	ut _ scriptedPlayer isUniversalTiles.
	ut ifTrue: [inner _ self newTilesFor: scriptedPlayer getter: slotSpec.
			cover _ (Morph new) color: Color transparent.
			cover extent: inner fullBounds extent.
			(getterButton _ cover copy) addMorph: cover; addMorphBack: inner.
			cover on: #mouseDown send: #newMakeGetter:from:forPart:
					to: self withValue: slotSpec]
		ifFalse: [r addMorphBack: self tileForSelf bePossessive.
			r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
			getterButton _ self getterButtonFor: slotName type: slotSpec fourth].
	r addMorphBack: getterButton.
	getterButton setBalloonText: slotSpec third.

	(slotName == #isOverColor) ifTrue: [
		self addIsOverColorDetailTo: r.
		^ r
	].
	(slotName == #touchesA) ifTrue: [
		self addTouchesADetailTo: r.
		^ r
	].

	(slotSpec fifth == #readOnly) ifFalse:
		[r addMorphBack: (Morph new color: self color; extent: 2@10).  " spacer"
		anArrow _ ut 
			ifTrue: [self arrowSetterButton: #newMakeSetter:from:forPart:
						args: slotSpec]
			ifFalse: [self arrowSetterButton: #makeSetter:from:forPart:
						args: (Array with: slotName with: slotSpec fourth)].
		r addMorphBack: anArrow.
		].
	r addMorphBack: (AlignmentMorph new beTransparent).  "flexible spacer"
	(#(colorSees playerSeeingColor copy touchesA) includes: slotName) ifFalse:
 		[r addMorphBack: (self readoutFor: slotName type: slotSpec fourth readOnly: slotSpec fifth getSelector: slotSpec seventh putSelector: slotSpec ninth)].

	anArrow ifNotNil: [anArrow step].
	^ r