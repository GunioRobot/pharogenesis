initialize
	"Initializes ST constants; C's are set by class>>declareCVarsIn:."
	self returnTypeC: 'void'.
	self cCode: '"nothing to do here"'
		inSmalltalk: 
			[andOpIndex _ 0.
			orOpIndex _ 1.
			xorOpIndex _ 2]