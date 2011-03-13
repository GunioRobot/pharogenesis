displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: aForm
	"Default display message when aDisplayPoint is in absolute screen
	coordinates."

	rule _ ruleInteger.
	mask _ aForm.
	clippingRectangle _ clipRectangle.
	compositionRectangle moveTo: aDisplayPoint.
	(lastLine == nil or: [lastLine < 1]) ifTrue: [self composeAll].
	self displayOn: aDisplayMedium lines: (1 to: lastLine)