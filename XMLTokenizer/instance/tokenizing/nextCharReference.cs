nextCharReference
	| base charValue nextChar numberString |
	self next == $#
		ifFalse: [self errorExpected: 'character reference'].
	base _ self peek == $x
		ifTrue: [
			self next.
			16]
		ifFalse: [10].
"	numberString _ (self nextUpTo: $;) asUppercase.
	charValue _ [Number readFrom: numberString base: base] on: Error do: [:ex | self errorExpected: 'Number.'].
"	charValue _ [self readNumberBase: base] on: Error do: [:ex | self errorExpected: 'Number.'].
	(nextChar _ self next) == $;
		ifFalse: [self errorExpected: '";"'].
	^charValue > 255
		ifTrue: [^Character space]
		ifFalse: [charValue asCharacter]