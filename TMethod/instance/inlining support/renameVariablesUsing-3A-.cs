renameVariablesUsing: aDictionary
	"Rename all variables according to old->new mappings of the given dictionary."

	| newDecls |
	"map args and locals"
	args _ args collect: [ :arg |
		(aDictionary includesKey: arg) ifTrue: [ aDictionary at: arg ] ifFalse: [ arg ].
	].
	locals _ locals collect: [ :v |
		(aDictionary includesKey: v) ifTrue: [ aDictionary at: v ] ifFalse: [ v ].
	].

	"map declarations"
	newDecls _ declarations species new.
	declarations associationsDo: [ :assoc |
		(aDictionary includesKey: assoc key)
			ifTrue: [ newDecls at: (aDictionary at: assoc key) put: assoc value ]
			ifFalse: [ newDecls add: assoc ].
	].
	declarations _ newDecls.

	"map variable names in parse tree"
	parseTree nodesDo: [ :node |
		(node isVariable and:
		 [aDictionary includesKey: node name]) ifTrue: [
			node setName: (aDictionary at: node name).
		].
		(node isStmtList and: [node args size > 0]) ifTrue: [
			node setArguments:
				(node args collect: [ :arg |
					(aDictionary includesKey: arg)
						ifTrue: [ aDictionary at: arg ]
						ifFalse: [ arg ].
				]).
		].
	].