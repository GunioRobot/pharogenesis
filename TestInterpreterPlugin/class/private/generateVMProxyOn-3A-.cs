generateVMProxyOn: fileName
	| cg proxyClass catList |
	proxyClass _ InterpreterProxy.
	cg _ TestCodeGenerator new initialize.
	cg addClass: proxyClass.
	catList _ proxyClass organization categories copy asOrderedCollection.
	catList remove: 'initialize' ifAbsent:[].
	catList remove: 'private' ifAbsent:[].
	catList _ catList collect:[:cat| cat -> (proxyClass organization listAtCategoryNamed: cat)].
	cg storeVirtualMachineProxyHeader: catList on: (fileName,'.h').
	cg storeVirtualMachineProxyImplementation: catList on: (fileName,'.c').

	"InterpreterProxy generateVMProxyOn:'sqVirtualMachine'"
