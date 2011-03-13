normalize
	"Check for leading zeroes and return shortened copy if so"
	| sLen val len oldLen minVal |
	"First establish len = significant length"
	len _ oldLen _ self digitLength.
	[len = 0 ifTrue: [^0].
	(self digitAt: len) = 0]
		whileTrue: [len _ len - 1].

	"Now check if in SmallInteger range"
	sLen _ 4  "SmallInteger minVal digitLength".
	len <= sLen ifTrue:
		[minVal _ SmallInteger minVal.
		(len < sLen
			or: [(self digitAt: sLen) < minVal lastDigit])
			ifTrue: ["If high digit less, then can be small"
					val _ 0.
					len to: 1 by: -1 do:
						[:i | val _ (val *256) - (self digitAt: i)].
					^ val].
		1 to: sLen do:  "If all digits same, then = minVal"
			[:i | (self digitAt: i) = (minVal digitAt: i)
					ifFalse: ["Not so; return self shortened"
							len < oldLen
								ifTrue: [^ self growto: len]
								ifFalse: [^ self]]].
		^ minVal].

	"Return self, or a shortened copy"
	len < oldLen
		ifTrue: [^ self growto: len]
		ifFalse: [^ self]