standardPositions
	"Return a list of standard window positions -- this may have one, two, or four of them, depending on the size and shape of the display screen.  5/22/96 sw"

	| anArea aList  midX midY |

	anArea _ Display usableArea.

	midX _ ScrollBarSetback +   ((anArea width - ScrollBarSetback)  // 2).
	midY _ ScreenTopSetback + ((anArea height - ScreenTopSetback) // 2).
	aList _ OrderedCollection with: (ScrollBarSetback @ ScreenTopSetback).
	self windowColumnsDesired > 1
		ifTrue:
			[aList add: (midX @ ScreenTopSetback)].
	self windowRowsDesired > 1
		ifTrue:
			[aList add: (ScrollBarSetback @ midY).
			self windowColumnsDesired > 1 ifTrue:
				[aList add: (midX @ midY)]].
	^ aList