asWords
	"SmallInteger maxVal asWords"
	| mils minus three num answer milCount |
	self = 0 ifTrue: [^'zero'].
	mils _ #('' ' thousand' ' million' ' billion' ' trillion' ' quadrillion' ' quintillion' ' sextillion' ' septillion' ' octillion' ' nonillion' ' decillion' ' undecillion' ' duodecillion' ' tredecillion' ' quattuordecillion' ' quindecillion' ' sexdecillion' ' septendecillion' ' octodecillion' ' novemdecillion' ' vigintillion').
	num _ self.
	minus _ ''.
	self < 0 ifTrue: [
		minus _ 'negative '.
		num _ num negated.
	].
	answer _ String new.
	milCount _ 1.
	[num > 0] whileTrue: [
		three _ (num \\ 1000) threeDigitName.
		num _ num // 1000.
		three isEmpty ifFalse: [
			answer isEmpty ifFalse: [
				answer _ ', ',answer
			].
			answer _ three,(mils at: milCount),answer.
		].
		milCount _ milCount + 1.
	].
	^minus,answer