clicked
	"The receiver or a highlight was clicked."

	self wantsClick ifFalse: [^false].
	self selectNextState.
	^true