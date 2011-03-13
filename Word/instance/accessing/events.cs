events
	| answer |
	answer := CompositeEvent new.
	self syllables do: [ :each | answer addAll: each events].
	^ answer