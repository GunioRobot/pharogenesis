controlActivity
	"Do one step of the Morphic interaction loop. Called repeatedly while window is active."

	self viewHasCursor
		ifTrue: [Sensor currentCursor == Cursor blank ifFalse: [Cursor blank show]]
		ifFalse: [Sensor currentCursor == Cursor normal ifFalse: [Cursor normal show]].
	model doOneCycle.