highBit
	"Answer the index of the high order bit of this number."
	| realLength lastDigit |
	realLength _ self digitLength.
	[(lastDigit _ self digitAt: realLength) = 0]
		whileTrue:
		[(realLength _ realLength - 1) = 0 ifTrue: [^ 0]].
	^ lastDigit highBit + (8 * (realLength - 1))