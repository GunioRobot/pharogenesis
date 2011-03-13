mouseDown: evt
	"If pane is not full, pass the event to the last submorph,
	assuming it is the most appropriate recipient (!)"
	scroller hasSubmorphs ifTrue:
		[scroller submorphs last mouseDown: (evt transformedBy: (scroller transformFrom: self))]