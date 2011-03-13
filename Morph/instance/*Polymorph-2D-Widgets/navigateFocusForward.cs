navigateFocusForward
	"Change the keyboard focus to the next morph."

	self nextMorphWantingFocus ifNotNilDo: [:m |
		m takeKeyboardFocus]
	