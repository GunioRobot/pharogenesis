inspectIt
	"1/13/96 sw: minor fixup"
	| result |
	self controlTerminate.
	(((result _ self evaluateSelection) isKindOf: FakeClassPool) or:
		[result == #failedDoit])
			ifFalse: [result inspect]
			ifTrue: [view flash].
	self controlInitialize