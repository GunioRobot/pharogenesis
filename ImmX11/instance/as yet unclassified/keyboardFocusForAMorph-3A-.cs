keyboardFocusForAMorph: aMorph

	| left bottom pos |
	aMorph ifNil: [^ self].
	[
		pos _ aMorph prefereredKeyboardPosition.
		left _ (pos x min: Display width max: 0) asInteger.
		bottom _ (pos y min: Display height max: 0) asInteger
			 + (aMorph paragraph
				characterBlockForIndex: aMorph editor selectionInterval first) height.
		self setCompositionWindowPositionX: left y: bottom
	] on: Error
	do: [:ex |].
