executeActions: type
	| rcvr |
	(events isNil or:[events isEmpty]) ifTrue:[^self].
	rcvr := target.
	rcvr ifNil:[rcvr := self ownerSprite].
	rcvr isNil ifTrue:[^self].
	(events at: type ifAbsent:[^self]) do:[:action|
		action sentTo: rcvr.
	].