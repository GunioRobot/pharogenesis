editAnnotations
	"Put up a window that allows the user to edit annotation specifications"

	| aWindow |
	self currentWorld addMorphCentered: (aWindow _ self annotationEditingWindow).
	aWindow activateAndForceLabelToShow

	"Preferences editAnnotations"

