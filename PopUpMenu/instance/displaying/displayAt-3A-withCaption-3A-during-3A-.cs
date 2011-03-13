displayAt: aPoint withCaption: captionOrNil during: aBlock 
	"Display the receiver just to the right of aPoint while aBlock is evaluated.  If the receiver is forced off screen, display it just to the right."
	| delta savedArea captionView captionSave outerFrame captionText tFrame frameSaveLoc |
	frame _ frame align: marker leftCenter with: aPoint + (2@0).
	outerFrame _ frame.
	captionOrNil notNil ifTrue:
		[captionText _ DisplayText
				text: captionOrNil asText
				textStyle: (TextStyle default copy alignment: 2).
		tFrame _ captionText boundingBox insetBy: -2.
		outerFrame _ frame merge: (tFrame align: tFrame bottomCenter
					with: frame topCenter + (0@2))].
	delta _ outerFrame amountToTranslateWithin: Display boundingBox.
	frame moveBy: delta.
	captionOrNil notNil ifTrue:
		[captionView _ DisplayTextView new model: captionText.
		captionView align: captionView boundingBox bottomCenter
					with: frame topCenter + (0@2).
		captionView insideColor: Display white.
		captionView borderWidth: 2.
		captionSave _ Form fromDisplay: captionView displayBox.
		captionView unlock; display; release].
	marker _ marker align: marker leftCenter with: aPoint + delta +  (2@0).
	savedArea _ Form fromDisplay: frame.
	form displayOn: Display at: (frameSaveLoc _ frame topLeft).
	selection ~= 0 ifTrue: [Display reverse: marker].
	aBlock value.
	savedArea displayOn: Display at: frameSaveLoc.
	captionOrNil notNil ifTrue:
		[captionSave displayOn: Display at: captionView displayBox topLeft]