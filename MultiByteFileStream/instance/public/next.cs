next

	| char secondChar state |
	char := self converter nextFromStream: self.
	self doConversion ifTrue: [
		char == Cr ifTrue: [
			state := converter saveStateOf: self.
			secondChar := self bareNext.
			secondChar ifNotNil: [secondChar == Lf ifFalse: [converter restoreStateOf: self with: state]].
		^Cr].
		char == Lf ifTrue: [^Cr].
	].
	^ char.

