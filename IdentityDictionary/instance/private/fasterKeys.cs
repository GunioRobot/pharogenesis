fasterKeys
	"This was taking some time in publishing and we didn't really need a Set"
	| answer index |
	answer := Array new: self size.
	index := 0.
	self keysDo: [:key | answer at: (index := index + 1) put: key].
	^ answer