encode: aString
	"CipherPanel encode: 'Now is the time for all good men to come to the aid of their country.'"

	| dict repeat |
	dict _ Dictionary new.
	repeat _ true.
	[repeat] whileTrue:
		[repeat _ false.
		($A to: $Z) with: ($A to: $Z) shuffled do:
			[:a :b | a = b ifTrue: [repeat _ true].
			dict at: a put: b]].
	^ aString asUppercase collect: [:a | dict at: a ifAbsent: [a]]