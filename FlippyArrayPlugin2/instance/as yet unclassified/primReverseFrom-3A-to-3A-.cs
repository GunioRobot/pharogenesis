primReverseFrom: fromInteger to: toInteger

	| rcvr t a b |
	rcvr _ self
		primitive:	'primReverseFromto'
		parameters:	#(SmallInteger SmallInteger)
		receiver:	#Array.

	a _ fromInteger - 1. b _ toInteger - 1.
	[a < b] whileTrue:
		[t _ rcvr at: a.
		 rcvr at: a put: (rcvr at: b).
		 rcvr at: b put: t.
		 a _ a + 1. b _ b - 1].
	^rcvr asOop: Array