keyboard
	"Answer the next character from the keyboard."
	| keycode |
	keycode := self primKbdNext.
	^keycode
		ifNotNil: [Unicode value: keycode]