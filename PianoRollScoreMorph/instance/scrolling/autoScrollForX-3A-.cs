autoScrollForX: x
	"Scroll by the amount x lies outside of my innerBounds.  Return true if this happens."

	| d ticks |
	((d _ x - self innerBounds right) > 0
		or: [(d _ x - self innerBounds left) < 0])
		ifTrue: [ticks _ (self timeForX: self bounds center x + d+1)
						min: score durationInTicks max: 0.
				self moveCursorToTime: ticks.
				scorePlayer ticksSinceStart: ticks.
				^ true].
	^ false
