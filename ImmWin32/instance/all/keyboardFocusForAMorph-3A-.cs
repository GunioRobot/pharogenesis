keyboardFocusForAMorph: aMorph

	| left top pos |
	aMorph ifNil: [^ self].
	[
		pos := aMorph preferredKeyboardPosition.
		left := (pos x min: Display width max: 0) asInteger.
		top := (pos y min: Display height max: 0) asInteger.
		self setCompositionWindowPositionX: left y: top
	] on: Error
	do: [:ex |].
