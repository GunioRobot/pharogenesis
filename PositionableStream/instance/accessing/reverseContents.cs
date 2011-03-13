reverseContents
	"Answer a copy of the receiver's contents, in reverse order."

	| size j newCollection |
	size _ j _ collection size.
	newCollection _ collection species new: size.
	1 to: size do: [:i | newCollection at: i put: (collection at: j). j _ j - 1].
	^newCollection