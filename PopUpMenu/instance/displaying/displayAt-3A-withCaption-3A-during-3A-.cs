displayAt: aPoint withCaption: captionOrNil during: aBlock
	"Display the receiver just to the right of aPoint while aBlock is evaluated.  If the receiver is forced off screen, display it just to the right."
	| delta savedArea captionForm captionSave outerFrame captionText tFrame frameSaveLoc captionBox |
	marker ifNil: [self computeForm].
	frame _ frame align: marker leftCenter with: aPoint + (2@0).
	outerFrame _ frame.
	captionOrNil notNil ifTrue:
		[captionText _ (DisplayText
				text: captionOrNil asText
				textStyle: MenuStyle copy centered)
					foregroundColor: Color black
					backgroundColor: Color white.
		tFrame _ captionText boundingBox insetBy: -2.
		outerFrame _ frame merge: (tFrame align: tFrame bottomCenter
					with: frame topCenter + (0@2))].
	delta _ outerFrame amountToTranslateWithin: Display boundingBox.
	frame right > Display boundingBox right
		ifTrue: [delta _ 0 - frame width @ delta y].
	frame _ frame translateBy: delta.
	captionOrNil notNil ifTrue:
		[captionForm _ captionText form.
		captionBox _ captionForm boundingBox expandBy: 4.
		captionBox _ captionBox align: captionBox bottomCenter
								with: frame topCenter + (0@2).
		captionSave _ Form fromDisplay: captionBox.
		Display border: captionBox width: 4 fillColor: Color white.
		Display border: captionBox width: 2 fillColor: Color black.
		captionForm displayAt: captionBox topLeft + 4].
	marker _ marker align: marker leftCenter with: aPoint + delta +  (2@0).
	savedArea _ Form fromDisplay: frame.
	self menuForm displayOn: Display at: (frameSaveLoc _ frame topLeft).
	selection ~= 0 ifTrue: [Display reverse: marker].
	Cursor normal showWhile: [aBlock value].
	savedArea displayOn: Display at: frameSaveLoc.
	captionOrNil notNil ifTrue:
		[captionSave displayOn: Display at: captionBox topLeft]