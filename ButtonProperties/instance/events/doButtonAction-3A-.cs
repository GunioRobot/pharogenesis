doButtonAction: evt

	| arity |

	target ifNil: [^self].
	actionSelector ifNil: [^self].
	arguments ifNil: [arguments _ #()].
	Cursor normal showWhile: [
		arity _ actionSelector numArgs.
		arity = arguments size ifTrue: [
			target perform: actionSelector withArguments: arguments
		].
		arity = (arguments size + 1) ifTrue: [
			target perform: actionSelector withArguments: {evt},arguments
		].
		arity = (arguments size + 2) ifTrue: [
			target perform: actionSelector withArguments: {evt. visibleMorph},arguments
		].
	]