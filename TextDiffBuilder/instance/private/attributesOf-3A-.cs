attributesOf: type
	"Private.
	Answer the TextAttributes that are used to display text of the given type."

	^type caseOf: {
		[#insert] -> [ {TextColor red} ].
		[#remove] -> [ {TextEmphasis struckOut. TextColor blue}].
	} otherwise: [ {TextEmphasis normal} ].
