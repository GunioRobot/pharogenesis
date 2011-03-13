rehash
	"Rehash the receiver. Reimplemented to allow for multiple nil keys"
	| oldArray assoc newIndex |
	oldArray := array.
	array := Array new: oldArray size.
	tally := 0.
	1 to: array size do:[:i|
		assoc := oldArray at: i.
		assoc ifNotNil:[
			newIndex := self scanForNil: assoc key.
			self atNewIndex: newIndex put: assoc.
		].
	].