mouseDown: evt

	hitLoc _ evt cursorPoint.
	editMode _ nil.
	owner submorphsDo:
		[:m | (m isKindOf: PianoRollNoteMorph) ifTrue: [m deselect]].
	selected _ true.
	self changed.
	owner selection: (Array with: trackIndex with: indexInTrack with: indexInTrack).
	self playSound