initCompilerHooks
	"Initialize hooks for the 'null compiler'"

	self cCode: 'compilerHooks[1]= nullCompilerHook'.
	self cCode: 'compilerHooks[2]= nullCompilerHook'.
	self cCode: 'compilerHooks[3]= nullCompilerHook'.
	self cCode: 'compilerHooks[4]= nullCompilerHook'.
	self cCode: 'compilerHooks[5]= nullCompilerHook'.
	self cCode: 'compilerHooks[6]= nullCompilerHook'.
	self cCode: 'compilerHooks[7]= nullCompilerHook'.
	self cCode: 'compilerHooks[8]= nullCompilerHook'.

	compilerInitialized _ false