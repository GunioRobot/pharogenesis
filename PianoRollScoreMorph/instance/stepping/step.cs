step

	| t |
	score ifNil: [^ self].

	lastMutedState ~= scorePlayer mutedState ifTrue: [
		self rebuildFromScore.
		lastMutedState _ scorePlayer mutedState copy].

	t _ scorePlayer ticksSinceStart.
	t = lastUpdateTick ifFalse: [
		self moveCursorToTime: t.
		lastUpdateTick _ t].
