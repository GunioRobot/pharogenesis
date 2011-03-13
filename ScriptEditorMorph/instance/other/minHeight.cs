minHeight

	| extra |
	extra _ 2 * (inset + borderWidth).
	^ (super minHeight - extra max: TileMorph defaultH) + extra
