verifyState
	"We are sure we will make a mark now.  Make sure the palette has not changed state while we were away.  If so, end this action and start another one.  6/11/97 19:52 tk  action, currentColor, brush"

	"Install the brush, color, (replace mode), and cursor."
	palette isInWorld ifFalse:
		[self world addMorphFront: palette].  "It happens.  might want to position it also"
		
	action == palette getSpecial ifFalse: [
		self invalidRect: rotationButton bounds.	"snap these back"
		rotationButton position: bounds topCenter - (6@0).		"later adjust by button width?"
		self invalidRect: rotationButton bounds.
		self invalidRect: scaleButton bounds.
		scaleButton position: bounds rightCenter - ((scaleButton width)@6).
		self invalidRect: scaleButton bounds.
		action == #polygon: ifTrue: [self polyFreeze].		"end polygon mode"
		^ action _ self prepareToPaint].
	action == #paint: ifTrue: [
		currentNib = palette getNib ifFalse: [
			currentNib _ palette getNib.
			"Change the nib on the cursor (Hand)"
			"get it to one bit depth.  For speed, instead of going through 
				a colorMap every time ."
			brush _ Form extent: currentNib extent depth: 1.
			brush offset: (0@0) - (brush extent // 2).
			currentNib displayOn: brush at: (0@0 - currentNib offset).
			paintingFormPen sourceForm: brush]].

	action == #erase: ifFalse: [
	 	currentColor = palette getColor ifFalse: [
			currentColor _ palette getColor.
			"Change the color of the nib on the cursor (Hand)"
			paintingFormPen color: currentColor.
			currentColor isTransparent 
				ifTrue: [
					paintingFormPen combinationRule: Form erase1bitShape.
					paintingFormPen color: Color black]
				ifFalse: [paintingFormPen combinationRule: Form paint]]]
		ifTrue: [palette getNib width = brush width ifFalse: [self erasePrep]].	"it changed"

	action == #stamp: ifTrue: [
		stampForm _ palette stampForm.	"get the current form"
		stampForm ifNil: [self error: 'no stamp']].
