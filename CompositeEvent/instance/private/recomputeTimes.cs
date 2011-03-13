recomputeTimes
	| oldTimedEvents |
	oldTimedEvents := timedEvents.
	timedEvents := SortedCollection new: oldTimedEvents size.
	oldTimedEvents do: [ :each | self add: each value]