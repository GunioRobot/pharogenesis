readScaledDecimal: integerPart fractionPart: fractionPart digits: fractionDigits base: base sign: sign from: aStream 
	"Complete creation of a ScaledDecimal, reading scale from aStream. Answer
	a ScaledDecimal, or nil if parsing fails.
	<number>s[<scale>]"

	| scale decimalMultiplier decimalFraction |
	aStream atEnd ifTrue: [^ nil].
	(aStream next == $s) ifFalse: [^ nil].
	"<number>s<scale>"
	(aStream peek digitValue between: 0 and: 10)
		ifTrue: [scale := Integer readFrom: aStream]
		ifFalse: [^ nil].
	scale isNil
		ifTrue: ["<number>s"
			fractionDigits = 0
				ifTrue: ["<integer>s"
					scale := 0]
				ifFalse: ["<integer>.<fraction>s"
					scale := fractionDigits]].
	fractionPart isNil
		ifTrue: [^ ScaledDecimal newFromNumber: integerPart * sign scale: scale]
		ifFalse: [decimalMultiplier := base raisedTo: fractionDigits.
			decimalFraction := integerPart * decimalMultiplier + fractionPart * sign / decimalMultiplier.
			^ ScaledDecimal newFromNumber: decimalFraction scale: scale]