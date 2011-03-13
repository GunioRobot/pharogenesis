mouseLeave: evt
	"When the mouse leaves our window release the keyboard focus"

	evt hand releaseKeyboardFocus: self.

	mode = #paint ifTrue: [evt hand showTemporaryCursor: nil]
