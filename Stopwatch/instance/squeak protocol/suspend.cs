suspend

	| ts |
	self isActive ifTrue:
		[ ts _ self timespans last.
		ts duration: (DateAndTime now - ts start).
		self state: #suspended]
