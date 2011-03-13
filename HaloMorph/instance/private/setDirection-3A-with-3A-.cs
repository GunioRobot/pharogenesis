setDirection: anEvent with: directionHandle
	"The user has let up after having dragged the direction arrow; now set the forward direction of the actual SketchMorph accordingly"
	| delta degrees |
	anEvent hand obtainHalo: self.
	delta _ (innerTarget transformFromWorld globalPointToLocal: directionHandle center) - innerTarget referencePosition.
	degrees _ delta degrees + 90.0.
	target forwardDirection: (degrees \\ 360) rounded.
	self endInteraction