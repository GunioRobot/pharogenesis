associations
	"Answer a Collection containing the receiver's associations."
	| out |
	out := (Array new: self size) writeStream.
	self associationsDo: [:value | out nextPut: value].
	^ out contents