showErrors

	letterMorphs do:
		[:m | (m letter ~= Character space and: [m letter ~= (quote at: m indexInQuote)])
			ifTrue: [m color: Color red.
					(quotePanel letterMorphs at: m indexInQuote) color: Color red]]