fasterKeys
	"This was taking some time in publishing and we didn't really need a Set"
	| answer index |
	answer _ Array new: self size.
	index _ 0.
	self keysDo: [:key | answer at: (index _ index + 1) put: key].
	^ answer