allBold
	"Force this whole text to be bold."

	string size = 0 ifTrue: [^self].
	self emphasizeFrom: 1 to: string size with: 2