standardWindowExtent
	"Answer the standard default extent for new windows.  5/23/96 sw"

	| effectiveExtent width strips height |
	effectiveExtent _ Display usableArea extent - (ScrollBarSetback @ ScreenTopSetback).
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