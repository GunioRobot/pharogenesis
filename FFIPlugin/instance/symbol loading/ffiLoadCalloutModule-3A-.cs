ffiLoadCalloutModule: module
	"Load the given module and return its handle"
	| moduleHandlePtr moduleHandle ffiModuleName moduleLength rcvr theClass ptr |
	self var: #ptr declareC:'int *ptr'.
	(interpreterProxy isBytes: module) ifTrue:[
		"plain module name"
		ffiModuleName _ module.
		moduleLength _ interpreterProxy byteSizeOf: ffiModuleName.
		moduleHandle _ interpreterProxy ioLoadModule: (self cCoerce: (interpreterProxy firstIndexableField: ffiModuleName) to:'int') OfLength: moduleLength.
		interpreterProxy failed ifTrue:[^self ffiFail: FFIErrorModuleNotFound]. "failed"
		^moduleHandle].
	"Check if the external method is defined in an external library"
	rcvr _ interpreterProxy stackValue: interpreterProxy methodArgumentCount.
	theClass _ interpreterProxy fetchClassOf: rcvr.
	(interpreterProxy includesBehavior: theClass 
			ThatOf: interpreterProxy classExternalLibrary) ifFalse:[^0].
	"external library"
	moduleHandlePtr _ interpreterProxy fetchPointer: 0 ofObject: rcvr.
	moduleHandle _ self ffiContentsOfHandle: moduleHandlePtr errCode: FFIErrorBadExternalLibrary.
	interpreterProxy failed ifTrue:[^0].
	moduleHandle = 0 ifTrue:["need to reload module"
		ffiModuleName _ interpreterProxy fetchPointer: 1 ofObject: rcvr.
		(interpreterProxy isBytes: ffiModuleName) ifFalse:[^self ffiFail: FFIErrorBadExternalLibrary].
		moduleLength _ interpreterProxy byteSizeOf: ffiModuleName.
		moduleHandle _ interpreterProxy ioLoadModule: (self cCoerce: (interpreterProxy firstIndexableField: ffiModuleName) to:'int') OfLength: moduleLength.
		interpreterProxy failed ifTrue:[^self ffiFail: FFIErrorModuleNotFound]. "failed"
		"and store back"
		ptr _ interpreterProxy firstIndexableField: moduleHandlePtr.
		ptr at: 0 put: moduleHandle].
	^moduleHandle