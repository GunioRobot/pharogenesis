events
	| answer |
	answer _ CompositeEvent new.
	self syllables do: [ :each | answer addAll: each events].
	^ answer