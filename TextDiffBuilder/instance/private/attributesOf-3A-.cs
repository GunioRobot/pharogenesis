attributesOf: type
	"Private.
	Answer the TextAttributes that are used to display text of the given type."

	^type caseOf: {
		[#insert] -> [ {TextEmphasis bold. TextColor color: Color green muchDarker} ].
		[#remove] -> [ {TextEmphasis bold. TextColor color: Color red darker} ].
	} otherwise: [ {TextEmphasis normal} ].
