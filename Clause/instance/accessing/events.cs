events
	| answer |
	answer := CompositeEvent new.
	self phrases do: [ :each | answer addAll: each events].
	^ answer