centerAlignLabelWith: aPoint
	"Align the center of the label with aPoint."

	| alignPt |
	alignPt _ label boundingBox center.
	(label isKindOf: Paragraph) ifTrue: 
		[alignPt _ alignPt + (0@(label textStyle leading))]. 
	label align: alignPt with: aPoint
