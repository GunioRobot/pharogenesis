next

	| char secondChar state |
	char _ self converter nextFromStream: self.
	self doConversion ifTrue: [
		char == Cr ifTrue: [
			state _ converter saveStateOf: self.
			secondChar _ self bareNext.
			secondChar ifNotNil: [secondChar == Lf ifFalse: [converter restoreStateOf: self with: state]].
		^Cr].
		char == Lf ifTrue: [^Cr].
	].
	^ char.

