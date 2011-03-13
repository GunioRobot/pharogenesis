compileVectorInstVarAccessorsFor: varName

	| nameString index type setPhrase |
	nameString _ varName asString capitalized.
	index _ info at: varName asSymbol.
	self class compileSilently: ('get', nameString, '
	^ ', '(arrays at: ', index printString, ')')
		classified: 'access'.

	type _ types at: index.
	type = #Number ifTrue: [
		setPhrase _ 'setNumberVarAt:'.
	].
	type = #Boolean ifTrue: [
		setPhrase _ 'setBooleanVarAt:'.
	].
	type = #Color ifTrue: [
		setPhrase _ 'setColorVarAt:'.
	].
	setPhrase ifNil: [setPhrase _ 'setObjectVarAt:'].

	self class compileSilently: ('set', nameString, ': xxxArg
	self ', setPhrase, index printString, ' put: xxxArg')
		classified: 'access'