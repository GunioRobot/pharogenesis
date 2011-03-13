clearRegistry
	Registry ifNotNilDo: 
			[:r |
			r finalizeValues.
			r do: [:k | k ifNotNil: [k beNull] ]].
	Registry := nil