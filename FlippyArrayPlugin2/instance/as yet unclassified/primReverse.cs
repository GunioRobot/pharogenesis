primReverse

	| rcvr t a b |
	rcvr _ self 
		primitive:	'primReverse'
		parameters:	#()
		receiver:	#Array.

	a _ 0. b _ rcvr size - 1.
	[a < b] whileTrue:
		[t _ rcvr at: a.
		 rcvr at: a put: (rcvr at: b).
		 rcvr at: b put: t.
		 a _ a + 1. b _ b - 1].
	^rcvr asOop: Array