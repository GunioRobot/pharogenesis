mouseMove: evt

	| delta offsetEvt |
	editMode == nil ifTrue:
		["First movement determines edit mode"
		((delta _ evt cursorPoint - hitLoc) dist: 0@0) <= 2 ifTrue:
			[^ self  "No significant movement yet."].
		delta x abs > delta y abs
			ifTrue: [delta x > 0  "Horizontal drag"
						ifTrue: [editMode _ #selectNotes]
						ifFalse: [self playSound: nil.
								offsetEvt _ evt copy setCursorPoint: evt cursorPoint + (20@0).
								self invokeNoteMenu: offsetEvt]]
			ifFalse: [editMode _ #editPitch  "Vertical drag"]].
	editMode == #editPitch ifTrue: [self editPitch: evt].
	editMode == #selectNotes ifTrue: [self selectNotes: evt].

