copy
	| answer |
	answer _ self class new: self size.
	self timedEvents do: [ :each | answer add: each value copy at: each key].
	^ answer