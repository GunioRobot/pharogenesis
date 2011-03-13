withColor: colorSymbol emphasis: emphasisSymbol do: aBlock

	^ self withAttributes: {TextColor color: (Color perform: colorSymbol).
							TextEmphasis perform: emphasisSymbol}
		do: aBlock