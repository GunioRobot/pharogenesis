readRemainderOf: integerPart from: aStream base: base withSign: sign 
	"Read optional fractional part and exponent or decimal scale, and return the final result"
	"Changed 200/01/19 For ANSI Numeric Literals support."
	"Number readFrom: '3r-22.2'"

	| value fraction fractionDigits fracpos fractionPart scaledDecimal |
	#Numeric.
	value := integerPart.
	fractionDigits := 0.
	(aStream peekFor: $.)
		ifTrue: ["<integer>.<fraction>"
			(aStream atEnd not
					and: [aStream peek digitValue between: 0 and: base - 1])
				ifTrue: [fracpos := aStream position.
					fractionPart := Integer readFrom: aStream base: base.
					fraction := fractionPart asFloat
								/ (base raisedTo: aStream position - fracpos).
					fractionDigits := aStream position - fracpos.
					value := value asFloat + fraction]
				ifFalse: [(self
							canParseExponentOrScaledDecimal: value
							integerPart: integerPart
							fractionPart: fractionPart
							digits: fractionDigits
							base: base
							sign: sign
							from: aStream)
						ifFalse: ["oops - just <integer>."
							aStream skip: -1.
							"un-gobble the period"
							^ value * sign]]].
	(self canParseAsScaledDecimal: integerPart
			fractionPart: fractionPart
			digits: fractionDigits
			base: base
			sign: sign
			from: aStream)
		ifTrue: ["<number>s[<scale>]"
			(scaledDecimal := self
						readScaledDecimal: integerPart
						fractionPart: fractionPart
						digits: fractionDigits
						base: base
						sign: sign
						from: aStream)
				ifNotNil: [^ scaledDecimal]].
	(self canParseExponentFor: value
			base: base
			from: aStream)
		ifTrue: ["<number>(e|d|q)<exponent>>"
			value := self
						readExponent: value
						base: base
						from: aStream].
	(value isFloat
			and: [value = 0.0
					and: [sign = -1]])
		ifTrue: [^ Float negativeZero]
		ifFalse: [^ value * sign]