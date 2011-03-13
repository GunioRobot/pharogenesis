inspectIt
	"1/13/96 sw: minor fixup"
	| result |
	result := self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [self flash]
			ifFalse: [result inspect].
