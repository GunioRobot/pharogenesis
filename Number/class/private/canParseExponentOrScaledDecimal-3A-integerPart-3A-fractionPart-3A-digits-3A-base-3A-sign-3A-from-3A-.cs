canParseExponentOrScaledDecimal: value integerPart: integerPart fractionPart: fractionPart digits: fractionDigits base: base sign: sign from: aStream 
	"Answer true if aStream contains parseable characters. The state of aStream is not changed."

	^ (self
			canParseExponentFor: value
			base: base
			from: aStream)
		or: [self
				canParseAsScaledDecimal: integerPart
				fractionPart: fractionPart
				digits: fractionDigits
				base: base
				sign: sign
				from: aStream]