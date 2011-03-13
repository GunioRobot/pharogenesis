quoteToScramble: aString
	"World addMorph: (CipherPanel quoteToScramble: 'Now is the time for all good men to come to the aid of their country.')"

	| dict |
	dict _ Dictionary new.
	($A to: $Z) with: ($A to: $Z) shuffled do: [:a :b | dict at: a put: b].
	^ self newFromQuote: (aString asUppercase collect: [:a | dict at: a ifAbsent: [a]])