compilePropagationMethods
	| varName |
	(self class organization listAtCategoryNamed: 'private - propagation' asSymbol)
		do: [:sel | varName _ sel allButLast.
			model class compilePropagationForVarName: varName slotName: slotName]