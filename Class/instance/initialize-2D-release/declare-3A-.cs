declare: varString 
	"Declare class variables common to all instances. Answer whether 
	recompilation is advisable."

	| newVars conflicts |
	newVars := 
		(Scanner new scanFieldNames: varString)
			collect: [:x | x asSymbol].
	conflicts := false.
	classPool == nil 
		ifFalse: [(classPool keys reject: [:x | newVars includes: x]) do: 
					[:var | self removeClassVarName: var]].
	(newVars reject: [:var | self classPool includesKey: var])
		do: [:var | "adding"
			"check if new vars defined elsewhere"
			(self bindingOf: var) notNil
				ifTrue: 
					[self error: var , ' is defined elsewhere'.
					conflicts := true]].
	newVars size > 0
		ifTrue: 
			[classPool := self classPool.
			"in case it was nil"
			newVars do: [:var | classPool declare: var from: Undeclared]].
	^conflicts