inspectIt
	"1/13/96 sw: minor fixup"
	| result |
	result _ self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [view flash]
			ifFalse: [result inspect].
