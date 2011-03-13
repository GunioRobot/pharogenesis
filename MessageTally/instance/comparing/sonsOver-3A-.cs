sonsOver: threshold

	| hereTally last sons |
	(receivers == nil or: [receivers size = 0]) ifTrue: [^#()].
	hereTally := tally.
	sons := receivers select:  "subtract subNode tallies for primitive hits here"
		[:son |
		hereTally := hereTally - son tally.
		son tally > threshold].
	hereTally > threshold
		ifTrue: [
			last := MessageTally new class: class method: method.
			last process: process.
			last reportOtherProcesses: reportOtherProcesses.
			^sons copyWith: (last primitives: hereTally)].
	^sons