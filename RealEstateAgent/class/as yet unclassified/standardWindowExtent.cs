standardWindowExtent
	"Answer the standard default extent for new windows.  "

	| effectiveExtent width strips height grid allowedArea maxLevel |
	effectiveExtent _ Display usableArea extent - (ScrollBarSetback @ ScreenTopSetback).
	Preferences reverseWindowStagger ifTrue:
		["NOTE: following copied from strictlyStaggeredInitialFrameFor:"
		allowedArea _ ScrollBarSetback @ ScreenTopSetback
						corner: Display usableArea bottomRight.
		"Number to be staggered at each corner (less on small screens)"
		maxLevel _ allowedArea area > 300000 ifTrue: [3] ifFalse: [2].
		"Amount by which to stagger (less on small screens)"
		grid _ allowedArea area > 500000 ifTrue: [40] ifFalse: [20].
		^ (allowedArea extent - (grid*(maxLevel+1*2) + (grid//2))) min: 600@400].
	width _ (strips _ self windowColumnsDesired) > 1
		ifTrue:
			[effectiveExtent x // strips]
		ifFalse:
			[(3 * effectiveExtent x) // 4].
	height _ (strips _ self windowRowsDesired) > 1
		ifTrue:
			[effectiveExtent y // strips]
		ifFalse:
			[(3 * effectiveExtent y) //4].
	^ width @ height

"RealEstateAgent standardWindowExtent"