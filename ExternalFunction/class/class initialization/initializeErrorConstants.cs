initializeErrorConstants
	"ExternalFunction initializeErrorConstants"
	FFIErrorMessages _ Dictionary new.
	#(
		"No callout mechanism available"
		(FFINoCalloutAvailable -1 'Callout mechanism not available')
		"generic error"
		(FFIErrorGenericError 0 'A call to an external function failed')
		"primitive invoked without ExternalFunction"
		(FFIErrorNotFunction 1 'Only ExternalFunctions can be called')
		"bad arguments to primitive call"
		(FFIErrorBadArgs 2 'Bad arguments in primitive invokation')

		"generic bad argument"
		(FFIErrorBadArg 3 'Bad argument for external function')
		"int passed as pointer"
		(FFIErrorIntAsPointer 4 'Cannot use integer as pointer')
		"bad atomic type (e.g., unknown)"
		(FFIErrorBadAtomicType 5 'Unknown atomic type in external call')
		"argument coercion failed"
		(FFIErrorCoercionFailed 6 'Could not coerce arguments')
		"Type check for non-atomic types failed"
		(FFIErrorWrongType 7 'Wrong type in external call')
		"struct size wrong or too large"
		(FFIErrorStructSize 8 'Bad structure size in external call')
		"unsupported calling convention"
		(FFIErrorCallType 9 'Unsupported calling convention')
		"cannot return the given type"
		(FFIErrorBadReturn 10 'Cannot return the given type')
		"bad function address"
		(FFIErrorBadAddress 11 'Bad function address')
		"no module given but required for finding address"
		(FFIErrorNoModule 12 'No module to load address from')
		"function address not found"
		(FFIErrorAddressNotFound 13 'Unable to find function address')
		"attempt to pass 'void' parameter"
		(FFIErrorAttemptToPassVoid 14 'Cannot pass ''void'' parameter')
		"module not found"
		(FFIErrorModuleNotFound 15 'External module not found')
		"external library invalid"
		(FFIErrorBadExternalLibrary 16 'External library is invalid')
		"external function invalid"
		(FFIErrorBadExternalFunction 17 'External function is invalid')
		"ExternalAddress points to ST memory (don't you dare to do this!)"
		(FFIErrorInvalidPointer 18 'Attempt to pass invalid pointer')
	) do:[:spec|
		FFIConstants declare: spec first from: Undeclared.
		FFIConstants at: spec first put: spec second.
		FFIErrorMessages at: spec second put: spec third.
	].