compileScalarInstVarAccessorsFor: varName

	| nameString type setPhrase arrayIndex getPhrase |
	nameString _ varName asString capitalized.
	arrayIndex _ turtles info at: varName asSymbol.

	type _ turtles types at: arrayIndex.
	type = #Number ifTrue: [
		setPhrase _ 'setNumberVarAt:'.
		getPhrase _ 'getNumberVarOf:'.
	].
	type = #Boolean ifTrue: [
		setPhrase _ 'setBooleanVarAt:'.
		getPhrase _ 'getBooleanVarOf:'
	].
	type = #Color ifTrue: [
		setPhrase _ 'setColorVarAt:'.
		getPhrase _ 'getColorVarOf:'
	].
	setPhrase ifNil: [setPhrase _ 'setObjectVarAt:'].
	getPhrase ifNil: [getPhrase _ 'getObjectVarOf:'].

	self class compileSilently: ('get', nameString, '
	^ self ', getPhrase, '((turtles arrays at: ', arrayIndex printString, ') at: self index)')
		classified: 'access'.

	self class compileSilently: ('set', nameString, ': xxxArg
		self ', setPhrase, arrayIndex printString, ' at: self index put: xxxArg' )
		classified: 'access'