fullContainsPoint: pt
	"The player clips its children"
	(bounds containsPoint: pt) ifFalse:[^false].
	^super fullContainsPoint: pt