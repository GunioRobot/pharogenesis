pointGriddedFromEvent: evt

	| relativePt |
	relativePt _ evt cursorPoint - self position.
	^ (relativePt x truncateTo: magnification)@(relativePt y truncateTo: magnification)
