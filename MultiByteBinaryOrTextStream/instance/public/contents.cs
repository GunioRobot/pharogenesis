contents

	| ret state |
	state _ converter saveStateOf: self.
	ret _ self upToEnd.
	converter restoreStateOf: self with: state.
	^ ret.
