placeInStructure: var
	"See if we should put this array into a structure
	This has hard coded vars, should go somewhere else!
	The variables listed are hardcoded as C in the interpreter thus they don't get resolved via TVariableNode logic
	Also Lets ignore variables that have special definitions that require initialization, 
	and the function def which has problems"

	| check |
	check _ variableDeclarations at: var ifAbsent: [''].
	(check includes: $=) ifTrue: [^false].
	(check includes: $() ifTrue: [^false].
	(check includes: $[) ifTrue: [^false].
	(#( 'showSurfaceFn' 'memory' 'extraVMMemory' 'interpreterProxy') includes: var) ifTrue: [^false].
	^true.
	