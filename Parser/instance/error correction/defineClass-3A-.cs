defineClass: className 
	"prompts the user to define a new class,
	asks for it's category, and lets the users edit further
	the definition"
	| sym  cat def d2 |
	sym := className asSymbol.
	cat := FillInTheBlank request: 'Enter class category : ' initialAnswer: 'Unknown'.
	cat ifEmpty: [cat := 'Unknown'].
	def := 'Object subclass: #', sym, '
		instanceVariableNames: '''' 
		classVariableNames: ''''
		poolDictionaries: ''''
		category: ''' , cat, ''''.
	d2 := FillInTheBlank request: 'Edit class definition : ' initialAnswer: def.
	d2 ifEmpty: [d2 := def].
	Compiler evaluate: d2.
	^ encoder global: (Smalltalk associationAt: sym) name: sym