events
	| answer |
	answer _ CompositeEvent new.
	self phrases do: [ :each | answer addAll: each events].
	^ answer