peekFor: item 

	| next state |
	"self atEnd ifTrue: [^ false]. -- SFStream will give nil"
	state _ converter saveStateOf: self.
	(next _ self next) == nil ifTrue: [^ false].
	item = next ifTrue: [^ true].
	converter restoreStateOf: self with: state.
	^ false.
