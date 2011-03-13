isAllWhite
	"Answer whether all bits in the receiver are white (=0)."

	bits do: [:data | data ~= 0 ifTrue: [^false]].
	^true