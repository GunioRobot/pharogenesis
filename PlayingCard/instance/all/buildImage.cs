buildImage     "(PlayingCard the: 12 of: #hearts) cardForm display"
	"World addMorph: (ImageMorph new image: (PlayingCard the: 12 of: #hearts) cardForm)"
	"PlayingCard test"
	| blt numForm suitForm spot face ace sloc colorMap fillColor |
	
	"Set up blt to copy in color for 1-bit forms"
	blt _ BitBlt current toForm: cardForm.
	fillColor _ self color.
	colorMap _ (((Array with: Color white with: fillColor)
				collect: [:c | cardForm pixelWordFor: c])
					 as: Bitmap).

	blt copy: cardForm boundingBox from: 0@0 in: self blankCard.  "Start with a blank card image"
	numForm _ NumberForms at: cardNo.  "Put number in topLeft"
	blt copyForm: numForm to: NumberLoc rule: Form over colorMap: colorMap.

	suitForm _ SuitForms at: suitNo*3-2.   "Put small suit just below number"
	sloc _ SuitLoc.
	cardNo > 10 ifTrue:
		[suitForm _ SuitForms at: suitNo*3-1.   "Smaller for face cards"
		sloc _ SuitLoc - (1@0)].
	blt copyForm: suitForm to: sloc rule: Form over colorMap: colorMap.

	cardNo <= 10
	ifTrue:
		["Copy top-half spots to the number cards"
		spot _ SuitForms at: suitNo*3.   "Large suit spots"
		(TopSpotLocs at: cardNo) do:
			[:loc | blt copyForm: spot to: loc rule: Form over colorMap: colorMap]]
	ifFalse:
		["Copy top half of face cards"
		face _ FaceForms at: suitNo-1*3 + 14-cardNo.
		blt colorMap: self faceColorMap;
			copy: (FaceLoc extent: face extent) from: 0@0 in: face].

	"Now copy top half to bottom"
	self copyTopToBottomHalf.

	cardNo <= 10 ifTrue:
		["Copy middle spots to the number cards"
		(MidSpotLocs at: cardNo) do:
			[:loc | blt copyForm: spot to: loc rule: Form over colorMap: colorMap]].
	(cardNo = 1 and: [suitNo = 4]) ifTrue:
		["Special treatment for the ace of spades"
		ace _ FaceForms at: 13.
		blt colorMap: self faceColorMap;
			copy: (ASpadesLoc extent: ace extent) from: 0@0 in: ace]
	