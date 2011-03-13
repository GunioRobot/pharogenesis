validateFrom: oldClass in: environ instanceVariableNames: invalidFields methods: invalidMethods 
	"Recompile the receiver, a class, and redefine its subclasses if necessary.
	The parameter invalidFields is no longer really used"

	| sub newSub invalidSubMethods |
	oldClass becomeUncompact.  "Its about to be abandoned"
	invalidMethods & self hasMethods
		ifTrue: 
			[Transcript show: 'recompiling ' , self name , '...'.
			self compileAllFrom: oldClass.
			Transcript show: ' done'; cr].
	invalidSubMethods _ invalidMethods | (self instSize ~= oldClass instSize).
	self == oldClass
		ifTrue: [invalidSubMethods ifFalse: [^self]]
		ifFalse: [self updateInstancesFrom: oldClass].
	oldClass subclasses do: 
		[:sub | 
		newSub _ sub copyForValidation.
		newSub
			subclassOf: self
			oldClass: sub
			instanceVariableNames: sub instVarNames
			variable: sub isVariable
			words: sub isBytes not
			pointers: sub isBits not
			ifBad: [self error: 'terrible problem in recompiling subclasses!'].
		newSub
			validateFrom: sub
			in: environ
			instanceVariableNames: invalidFields
			methods: invalidSubMethods]