duration

	| ts last |
	self isSuspended 
		ifTrue:
			[ (ts _ self timespans) isEmpty ifTrue: 
				[ ts _ { Timespan starting: DateAndTime now duration: Duration zero } ] ]
		ifFalse:
			[ last _ self timespans last.
			ts _ self timespans allButLast
				add: (last duration: (DateAndTime now - last start); yourself);
				yourself ].
		
	^ (ts collect: [ :t | t duration ]) sum
