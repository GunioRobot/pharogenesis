toSystemClipboard: text

	| string |
	"self halt."
	string _ text asString.
	string isAsciiString ifTrue: [^ string asOctetString].
	string isOctetString ifTrue: [^ string "hmm"].
	^ string convertToWithConverter: ShiftJISTextConverter new .
