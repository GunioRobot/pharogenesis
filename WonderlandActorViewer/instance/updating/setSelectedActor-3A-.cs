setSelectedActor: anActor
	"Update the actor viewer to reflect the information for this actor"

	selectedActor _ anActor.

	thumbnailCamera setFocusObject: anActor.
	dataMorph setActor: anActor.


