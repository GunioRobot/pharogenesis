cFunctionNameFor: aSelector
	"Create a C function name from the given selector by omitting colons."

	^aSelector copyWithout: $: