scrollBy: delta
	"Move the contents in the direction delta."
	"For now, delta is assumed to have a zero x-component"
	| r newOffset |

	newOffset _ (scroller offset - delta max: 0@0) min: self totalScrollRange.
	scroller offset: newOffset.

	r _ self totalScrollRange.
	r y = 0
		ifTrue: [yScrollBar value: 0.0]
		ifFalse: [yScrollBar value: newOffset y asFloat / r y].
	r x = 0
		ifTrue: [xScrollBar value: 0.0]
		ifFalse: [xScrollBar value: newOffset x asFloat / r x].
