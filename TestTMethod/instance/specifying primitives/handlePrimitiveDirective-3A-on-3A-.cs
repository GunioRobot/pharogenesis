handlePrimitiveDirective: aStmt on: sStream

	isPrimitive _ true.
	fullArgs _ args.
	locals addAll: args.
	args _ OrderedCollection new.
	fullArgs with: parmSpecs do:
		[:argName :spec |
			declarations
				at: argName
				put: (spec ccgDeclareCForVar: argName)].
	aStmt isAssignment ifTrue:
		[declarations
			at: aStmt variable name
			put: (rcvrSpec ccgDeclareCForVar: aStmt variable name).
		 sStream nextPutAll: (self
			statementsFor:
				(rcvrSpec
					ccg:		TestCodeGenerator new
					prolog:  [:expr | aStmt variable name, ' _ ', expr]
					expr: 	aStmt variable name
					index: 	(fullArgs size))
			varName: '')].

	"only add the failure guard if there are args or it is an assignment"
	(fullArgs isEmpty not or:[aStmt isAssignment]) ifTrue:[self generateFailureGuardOn: sStream].
	^true.
