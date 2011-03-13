showStats
"
CanvasEncoder showStats
"
	| answer bucket |

	SentTypesAndSizes ifNil: [^Beeper beep].
	answer := WriteStream on: String new.
	SentTypesAndSizes keys asSortedCollection do: [ :each |
		bucket := SentTypesAndSizes at: each.
		answer nextPutAll: each printString,' ',
				bucket first printString,'  ',
				bucket second asStringWithCommas,' ',
				(self nameForCode: each); cr.
	].
	StringHolder new contents: answer contents; openLabel: 'send/receive stats'.
