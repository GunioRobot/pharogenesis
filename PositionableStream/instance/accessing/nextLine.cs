nextLine
	"Answer next line (may be empty), or nil if at end"

	self atEnd ifTrue: [^nil].
	^self upTo: Character cr