declareCVarsIn: cg

	cg addHeaderFile:'"rePlugin.h"'.

	"Memory Managament Error Checking"
	cg var: 'netMemory' 	declareC: 'int netMemory = 0'.
	cg var: 'numAllocs' 	declareC: 'int numAllocs = 0'.
	cg var: 'numFrees' 		declareC: 'int numFrees = 0'.
	cg var: 'lastAlloc'		declareC: 'int lastAlloc = 0'.

	"The receiver Object Pointer"
	cg var: 'rcvr'			declareC: 'int rcvr'.

	"Instance Variables of Receiver Object"
	cg var: 'patternStr'		declareC: 'int patternStr'.
	cg var: 'compileFlags'	declareC: 'int compileFlags'.
	cg var: 'pcrePtr'		declareC: 'int pcrePtr'.
	cg var: 'extraPtr'		declareC: 'int extraPtr'.
	cg var: 'errorStr'		declareC: 'int errorStr'.
	cg var: 'errorOffset'	declareC: 'int errorOffset'.
	cg var: 'matchFlags'	declareC: 'int matchFlags'.

	"Support Variables for Access to Receiver Instance Variables"
	cg var: 'patternStrPtr' declareC: 'const char * patternStrPtr'.
	cg var: 'errorStrBuffer'	declareC: 'const char * errorStrBuffer'.