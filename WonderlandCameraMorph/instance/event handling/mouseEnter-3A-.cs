mouseEnter: evt
	"When the mouse enters our window give it the keyboard focus"

	evt hand newKeyboardFocus: self.

	mode = #paint ifTrue: [evt hand showTemporaryCursor: palette actionCursor].
