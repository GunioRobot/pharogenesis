executeActions: type
	| rcvr |
	(events isNil or:[events isEmpty]) ifTrue:[^self].
	rcvr _ target.
	rcvr ifNil:[rcvr _ self ownerSprite].
	rcvr isNil ifTrue:[^self].
	(events at: type ifAbsent:[^self]) do:[:action|
		action sentTo: rcvr.
	].