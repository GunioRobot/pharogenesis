testAll	"FFITester testAll"
	"Run all the tests"
	"Pass 1: Run all the methods in the class and see if it works"
	"Pass 2: Run all the methods in an instance (ExternalLibrary) and see if it works"
	"Pass 3: Run all the methods directly invoked from an ExternalMethod"
	| rcvr value meth module |
	1 to: 2 do:[:i|
		i = 1 ifTrue:[rcvr _ self] ifFalse:[rcvr _ self new].
		"Test argument coercion and passing of arguments of different sizes"
		rcvr ffiTestChar: $A with: 65 with: 65.0 with: true.
		rcvr ffiTestShort: $A with: 65 with: 65.0 with: true.
		rcvr ffiTestInt: $A with: 65 with: 65.0 with: true.
		value _ rcvr ffiTestFloats: $A with: 65.0.
		value rounded = 130 ifFalse:[self error:'single floats don''t work'].
		value _ rcvr ffiTestDoubles: 41 with: true.
		value = 42.0 ifFalse:[self error:'problem with doubles'].
		value _ rcvr ffiPrintString:'Hello World!'.
		value = 'Hello World!' ifFalse:[self error:'Problem with strings'].
	].
	module _ self moduleName.
	meth _ ExternalLibraryFunction
		name:'ffiTestChars' module: module callType: 0 returnType: ExternalType char
		argumentTypes: ((1 to: 4) collect:[:i| ExternalType char]).
	meth invokeWith: $A with: 65 with: 65.0 with: true.
	meth _ ExternalLibraryFunction
		name:'ffiTestShorts' module: module callType: 0 returnType: ExternalType short
		argumentTypes: ((1 to: 4) collect:[:i| ExternalType short]).
	meth invokeWithArguments: (Array with: $A with: 65 with: 65.0 with: true).
	meth _ ExternalLibraryFunction
		name:'ffiTestInts' module: module callType: 0 returnType: ExternalType long
		argumentTypes: ((1 to: 4) collect:[:i| ExternalType long]).
	meth invokeWith: $A with: 65 with: 65.0 with: true.

	meth _ ExternalLibraryFunction
		name:'ffiTestFloats' module: module callType: 0 returnType: ExternalType float
		argumentTypes: ((1 to: 2) collect:[:i| ExternalType float]).
	value _ meth invokeWith: $A with: 65.0.
	value rounded = 130 ifFalse:[self error:'single floats don''t work'].

	meth _ ExternalLibraryFunction
		name:'ffiTestDoubles' module: module callType: 0 returnType: ExternalType double
		argumentTypes: ((1 to: 2) collect:[:i| ExternalType double]).
	value _ meth invokeWithArguments: (Array with: 41 with: true).
	value = 42.0 ifFalse:[self error:'problem with doubles'].

	meth _ ExternalLibraryFunction
		name:'ffiPrintString' module: module callType: 0 returnType: ExternalType string
		argumentTypes: ((1 to: 1) collect:[:i| ExternalType string]).
	value _ meth invokeWith:'Hello World!'.
	value = 'Hello World!' ifFalse:[self error:'Problem with strings'].
