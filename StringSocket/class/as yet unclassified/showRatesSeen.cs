showRatesSeen
"
StringSocket showRatesSeen
"
	| answer |

	MaxRatesSeen ifNil: [^1 beep].
	answer _ WriteStream on: String new.
	MaxRatesSeen keys asSortedCollection do: [ :key |
		answer nextPutAll: key printString,'  ',((MaxRatesSeen at: key) // 10000) printString; cr
	].
	StringHolder new contents: answer contents; openLabel: 'send rates at 10 second intervals'.