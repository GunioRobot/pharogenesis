= aMessageTally

	self species == aMessageTally species ifFalse: [^ false].
	^ aMessageTally method == method