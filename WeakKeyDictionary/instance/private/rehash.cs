rehash
	"Rehash the receiver. Reimplemented to allow for multiple nil keys"
	| oldArray assoc newIndex |
	oldArray _ array.
	array _ Array new: oldArray size.
	tally _ 0.
	1 to: array size do:[:i|
		assoc _ oldArray at: i.
		assoc ifNotNil:[
			newIndex _ self scanForNil: assoc key.
			self atNewIndex: newIndex put: assoc.
		].
	].