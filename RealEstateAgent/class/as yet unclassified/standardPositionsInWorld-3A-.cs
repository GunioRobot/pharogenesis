standardPositionsInWorld: aWorldOrNil
	"Return a list of standard window positions -- this may have one, two, or four of them, depending on the size and shape of the display screen.  "

	| anArea aList  midX midY |

	anArea _ self maximumUsableAreaInWorld: aWorldOrNil.

	midX _ self scrollBarSetback +   ((anArea width - self scrollBarSetback)  // 2).
	midY _ self screenTopSetback + ((anArea height - self screenTopSetback) // 2).
	aList _ OrderedCollection with: (self scrollBarSetback @ self screenTopSetback).
	self windowColumnsDesired > 1
		ifTrue:
			[aList add: (midX @ self screenTopSetback)].
	self windowRowsDesired > 1
		ifTrue:
			[aList add: (self scrollBarSetback @ (midY+self screenTopSetback)).
			self windowColumnsDesired > 1 ifTrue:
				[aList add: (midX @ (midY+self screenTopSetback))]].
	^ aList