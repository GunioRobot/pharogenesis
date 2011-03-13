centerAlignLabelWith: aPoint
	"Align the center of the label with aPoint."

	| alignPt |
	alignPt := label boundingBox center.
	(label isKindOf: Paragraph) ifTrue: 
		[alignPt := alignPt + (0@(label textStyle leading))]. 
	(label isForm)
	  ifTrue: [label offset: 0 @ 0].
	label align: alignPt with: aPoint
