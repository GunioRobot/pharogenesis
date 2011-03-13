setProjectHolder: aProject

	world _ ControlManager new.
	changeSet _ ChangeSet new initialize.
	transcript _ TranscriptStream new.
	displayDepth _ Display depth.
	parentProject _ aProject