keyboardFocusForAMorph: aMorph

	| left top pos |
	aMorph ifNil: [^ self].
	[
		pos _ aMorph prefereredKeyboardPosition.
		left _ (pos x min: Display width max: 0) asInteger.
		top _ (pos y min: Display height max: 0) asInteger.
		self setCompositionWindowPositionX: left y: top
	] on: Error
	do: [:ex |].
