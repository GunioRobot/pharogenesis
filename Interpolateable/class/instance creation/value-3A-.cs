value: aValue
	"Create and initialize a new interpolateable value."

	| newInterp |
	newInterp _ Interpolateable new.
	newInterp setValue: aValue.
	^ newInterp.
