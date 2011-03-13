isAllWhite
	"Answer whether all bits in the receiver are white (=0)."

	self unhibernate.
	1 to: bits size do: [:i | (bits at: i) = 0 ifFalse: [^ false]].
	^ true