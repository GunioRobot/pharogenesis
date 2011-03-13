xxxminHeight

	| extra |
	extra _ 2 * (self layoutInset + borderWidth).
	^ (super minHeight - extra max: TileMorph defaultH) + extra
