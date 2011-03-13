events
	| answer |
	answer := CompositeEvent new.
	self words do: [ :each | answer addAll: each events].
	^ answer