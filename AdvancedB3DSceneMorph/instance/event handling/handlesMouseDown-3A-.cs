handlesMouseDown: evt
	evt yellowButtonPressed ifTrue: [^false] ifFalse: [^true]
