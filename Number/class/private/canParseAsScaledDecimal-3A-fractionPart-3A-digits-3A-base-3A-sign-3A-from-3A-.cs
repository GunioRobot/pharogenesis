canParseAsScaledDecimal: integerPart fractionPart: fractionPart digits: fractionDigits base: base sign: sign from: aStream 
	"Answer true if parsing a ScaleDecimal will succeed. Read from a copy  
	of aStream to test the parsing."

	^ aStream peek == $s
		and: [(self
				readScaledDecimal: integerPart
				fractionPart: fractionPart
				digits: fractionDigits
				base: base
				sign: sign
				from: aStream copy) notNil]