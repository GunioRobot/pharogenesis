segments
	"Return all the segments in the receiver"
	| out |
	out _ WriteStream on: Array new.
	self segmentsDo:[:seg| out nextPut: seg].
	^out contents