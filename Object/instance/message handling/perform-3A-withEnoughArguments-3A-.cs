perform: selector withEnoughArguments: anArray
	"Send the selector, aSymbol, to the receiver with arguments in argArray.
	Only use enough arguments for the arity of the selector; supply nils for missing ones."
	| numArgs args |
	numArgs _ selector numArgs.
	anArray size == numArgs
		ifTrue: [ ^self perform: selector withArguments: anArray asArray ].

	args _ Array new: numArgs.
	args replaceFrom: 1
		to: (anArray size min: args size)
		with: anArray
		startingAt: 1.

	^ self perform: selector withArguments: args