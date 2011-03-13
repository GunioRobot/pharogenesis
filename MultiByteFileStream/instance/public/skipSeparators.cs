skipSeparators

	| state |
	[self atEnd] whileFalse: [
		state := converter saveStateOf: self.
		self next isSeparator ifFalse: [
			^ converter restoreStateOf: self with: state]]


"	[self atEnd] whileFalse: [
		self next isSeparator ifFalse: [
			^ self position: self position - converter currentCharSize.
		].
	].
"
