inlineMethodsUsing: aDictionary

	arguments _ arguments collect: [ :arg |
		arg inlineMethodsUsing: aDictionary.
	].
	"xxx inline this message if it is in the dictionary xxx"