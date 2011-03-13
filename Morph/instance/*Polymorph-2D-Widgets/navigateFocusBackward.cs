navigateFocusBackward
	"Change the keyboard focus to the previous morph."

	self previousMorphWantingFocus ifNotNilDo: [:m |
		m takeKeyboardFocus]
	