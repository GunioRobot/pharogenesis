primitiveForceLoad
	"Primitive. Force loading the receiver (an instance of ExternalLibrary)."
	| rcvr theClass moduleHandlePtr moduleHandle ffiModuleName moduleLength ptr |
	self export: true.
	self inline: false.
	self var: #ptr declareC:'int *ptr'.
	self ffiSetLastError: FFIErrorGenericError. "educated guess if we fail silently"
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	rcvr _ interpreterProxy stackValue: 0.
	theClass _ interpreterProxy fetchClassOf: rcvr.
	(interpreterProxy includesBehavior: theClass 
			ThatOf: interpreterProxy classExternalLibrary) 
				ifFalse:[^self ffiFail: FFIErrorBadExternalLibrary].
	moduleHandlePtr _ interpreterProxy fetchPointer: 0 ofObject: rcvr.
	moduleHandle _ self ffiContentsOfHandle: moduleHandlePtr errCode: FFIErrorBadExternalLibrary.
	interpreterProxy failed ifTrue:[^0].
	ffiModuleName _ interpreterProxy fetchPointer: 1 ofObject: rcvr.
	(interpreterProxy isBytes: ffiModuleName) 
		ifFalse:[^self ffiFail: FFIErrorBadExternalLibrary].
	moduleLength _ interpreterProxy byteSizeOf: ffiModuleName.
	moduleHandle _ interpreterProxy ioLoadModule: (self cCoerce: (interpreterProxy firstIndexableField: ffiModuleName) to:'int') OfLength: moduleLength.
	interpreterProxy failed ifTrue:[^self ffiFail: FFIErrorModuleNotFound]. "failed"
	"and store back"
	ptr _ interpreterProxy firstIndexableField: moduleHandlePtr.
	ptr at: 0 put: moduleHandle.
	^0 "done"