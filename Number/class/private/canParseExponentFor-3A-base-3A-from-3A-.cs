canParseExponentFor: baseValue base: base from: aStream 
	"Answer true if parsing the expoenent for a number will succeed. Read from
	a copy of aStream to test the parsing."

	^ ('edq' includes: aStream peek)
		and: [(self
				readExponent: baseValue
				base: base
				from: aStream copy) notNil]