setCompositionWindow

	| hand |
	hand _ self primaryHand.
	hand ifNotNil: [hand compositionWindowManager keyboardFocusForAMorph: self].
