undoHideFor: anActor
	"Create an undo event that will show the actor"

	^ (self new) setActorForHide: anActor.
