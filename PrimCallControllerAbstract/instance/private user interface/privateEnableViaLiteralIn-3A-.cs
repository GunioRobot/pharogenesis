privateEnableViaLiteralIn: aMethodRef 
	"Enables external prim call by filling function ref literal with zero for 
	'non called'."
	aMethodRef compiledMethod literals first at: 4 put: 0.
	Object flushCache