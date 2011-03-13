undoFromCapturedState: st 

	self copyFrom: st first.
	st second do: [:assn | (submorphs at: assn key) copyFrom: assn value].
	selection ifNotNil:
		[selection do: [:loc | (self tileAt: loc) setSwitchState: false; color: selectionColor].
		selection _ nil].
	owner scoreDisplay flash: st third.  "score display"
	owner scoreDisplay value: st fourth.
	self changed.