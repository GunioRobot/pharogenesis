events
	| answer |
	answer _ CompositeEvent new.
	self words do: [ :each | answer addAll: each events].
	^ answer