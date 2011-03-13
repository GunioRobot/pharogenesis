initializeFromParagraph: aParagraph clippedBy: clippingRectangle

	text _ aParagraph text.
	textStyle _ aParagraph textStyle. 
	destForm _ aParagraph destinationForm.
	self fillColor: aParagraph fillColor.	"sets halftoneForm"
	self combinationRule: aParagraph rule.
	self clipRect: clippingRectangle.
	sourceY _ 0