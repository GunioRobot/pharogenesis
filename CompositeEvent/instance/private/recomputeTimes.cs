recomputeTimes
	| oldTimedEvents |
	oldTimedEvents _ timedEvents.
	timedEvents _ SortedCollection new: oldTimedEvents size.
	oldTimedEvents do: [ :each | self add: each value]