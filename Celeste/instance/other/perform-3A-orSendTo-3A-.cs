perform: selector orSendTo: otherTarget
	"Celeste handles all menu commands."

	selector = #format ifTrue: [^ self perform: selector].

	((#(yellowButtonActivity shiftedYellowButtonActivity) includes: selector) or:
		[(ParagraphEditor yellowButtonMessages includes: selector) or:
		[ParagraphEditor shiftedYellowButtonMenu selections includes: selector]])
			ifTrue: [otherTarget perform: selector]
			ifFalse: [self perform: selector].
