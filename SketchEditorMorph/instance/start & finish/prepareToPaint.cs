prepareToPaint
	"Figure out what the current brush, fill, etc is.  Return an action to take every mouseMove.  Set up instance variable and pens.  Prep for normal painting is inlined here.  tk 6/14/97 21:11"

	| specialMode |
	"Install the brush, color, (replace mode), and cursor."
	specialMode _ palette getSpecial.
 	currentColor  _ palette getColor.
	brush _ currentNib _ palette getNib.
	paintingFormPen _ Pen newOnForm: paintingForm.
	stampForm _ nil.	"let go of stamp"
	formCanvas _ paintingForm getCanvas.	"remember to change when undo"
	formCanvas _ formCanvas
		copyOrigin: self topLeft negated
		clipRect: (0@0 extent: bounds extent).

	specialMode == #paint: ifTrue: [
		"get it to one bit depth.  For speed, instead of going through a colorMap every time ."
		brush _ Form extent: brush extent depth: 1.
		brush offset: (0@0) - (brush extent // 2).
		currentNib displayOn: brush at: (0@0 - currentNib offset).

		paintingFormPen sourceForm: brush.
		paintingFormPen combinationRule: Form paint.
		paintingFormPen color: currentColor.
		currentColor isTransparent ifTrue: [
			paintingFormPen combinationRule: Form erase1bitShape.
			paintingFormPen color: Color black].
		^ #paint:].

	specialMode == #erase: ifTrue: [
		self erasePrep.
		^ #erase:].
	specialMode == #stamp: ifTrue: [
		stampForm _ palette stampForm.	"keep it"
		^ #stamp:].

	(self respondsTo: specialMode) 
		ifTrue: [^ specialMode]	"fill: areaFill: pickup: (in mouseUp:) 
				rect: ellipse: line: polygon: star:"
		ifFalse: ["Don't recognise the command"
			palette setAction: #paint:.	"set it to Paint"
			^ self prepareToPaint].