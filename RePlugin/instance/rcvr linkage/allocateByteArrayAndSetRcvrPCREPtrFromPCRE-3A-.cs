allocateByteArrayAndSetRcvrPCREPtrFromPCRE: aPCREPtr

	| patObject patByteArrayPtr |
	self var: #patByteArrayPtr declareC: 'void *patByteArrayPtr'.

	"Allocate a Smalltalk ByteArray -- lastAlloc contains the length"
	patObject _ interpreterProxy
				instantiateClass: (interpreterProxy classByteArray) 
				indexableSize: lastAlloc.
	self loadRcvrFromStackAt: 0. "Assume garbage collection after instantiation"

	"Copy from the C bytecode buffer to the Smalltalk ByteArray"
	patByteArrayPtr _ interpreterProxy arrayValueOf: patObject.	
	self cCode:'memcpy(patByteArrayPtr, (void *) aPCREPtr, lastAlloc)'.
 
	"Set rcvrErrorStr from errorStr and Return"
	self rcvrPCREBufferFrom: patObject.
	self touch: patByteArrayPtr.	
	^patObject.
