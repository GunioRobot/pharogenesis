inlineMethodsUsing: aDictionary

	expression inlineMethodsUsing: aDictionary.
	cases do: [ :c | c inlineMethodsUsing: aDictionary ].