literalFromContents
	| label |
	label _ self labelMorph
				ifNil: [^ super literal].
	label step.
	^ literal _ label valueFromContents