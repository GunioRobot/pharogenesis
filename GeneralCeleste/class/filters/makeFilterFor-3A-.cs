makeFilterFor: filterExpr
	"compile a given custom filter"
	^Compiler evaluate: '[ :m | ', filterExpr, ']'.

