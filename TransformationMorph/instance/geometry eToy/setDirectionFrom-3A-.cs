setDirectionFrom: aPoint
	| delta degrees inner |
	inner _ self renderedMorph.
	inner == self ifTrue:[^self].
	delta _ (inner transformFromWorld globalPointToLocal: aPoint) - inner referencePosition.
	degrees _ delta degrees + 90.0.
	self forwardDirection: (degrees \\ 360) rounded.
