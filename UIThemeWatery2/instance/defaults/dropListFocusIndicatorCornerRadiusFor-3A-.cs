dropListFocusIndicatorCornerRadiusFor: aDropList
	"Answer the default corner radius preferred for the focus indicator
	for the drop list for themes that support this."

	^aDropList wantsRoundedCorners
		ifTrue: [4]
		ifFalse: [2]