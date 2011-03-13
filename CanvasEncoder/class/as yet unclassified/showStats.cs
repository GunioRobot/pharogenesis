showStats
"
CanvasEncoder showStats
"
	| answer bucket |

	SentTypesAndSizes ifNil: [^1 beep].
	answer _ WriteStream on: String new.
	SentTypesAndSizes keys asSortedCollection do: [ :each |
		bucket _ SentTypesAndSizes at: each.
		answer nextPutAll: each printString,' ',
				bucket first printString,'  ',
				bucket second asStringWithCommas,' ',
				(self nameForCode: each); cr.
	].
	StringHolder new contents: answer contents; openLabel: 'send/receive stats'.
