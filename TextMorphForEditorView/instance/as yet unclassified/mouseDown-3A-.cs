mouseDown: evt
	"Pass to any highlight too."

	|hl|
	super mouseDown: evt.
	hl := self editView highlights
		detect: [:h |
			h containsPoint: evt position
			in: (self bounds: self editView innerBounds from: self)]
		ifNone: [^self].
	hl clicked: evt