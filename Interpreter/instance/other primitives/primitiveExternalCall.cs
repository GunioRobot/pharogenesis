primitiveExternalCall
	"Call an external primitive. The external primitive methods contain as first literal an array consisting of:
		* The module name (String | Symbol)
		* The function name (String | Symbol)
		* The session ID (SmallInteger) [OBSOLETE]
		* The function address (Integer)
	For fast failures the primitive index of any method where the external prim is not found is rewritten in the method cache with zero. This allows for ultra fast responses as long as the method stays in the cache.
	The fast failure response relies on lkupClass being properly set. This is done in #addToMethodCacheSel:class:method:primIndex: to compensate for execution of methods that are looked up in a superclass (such as in primitivePerformAt).
	With the latest modifications (e.g., actually flushing the function addresses from the VM), the session ID is obsolete. But for backward compatibility it is still kept around. Also, a failed lookup is reported specially. If a method has been looked up and not been found, the function address is stored as -1 (e.g., the SmallInteger -1 to distinguish from 16rFFFFFFFF which may be returned from the lookup).
	It is absolutely okay to remove the rewrite if we run into any problems later on. It has an approximate speed difference of 30% per failed primitive call which may be noticable but if, for any reasons, we run into problems (like with J3) we can always remove the rewrite.
	"
	| lit functionAddress addr moduleName functionName moduleLength functionLength index |
	"Fetch the first literal of the method"
	self success: (self literalCountOf: newMethod) > 0."@@: Could this be omitted for speed?!"
	successFlag ifFalse:[^nil].
	lit _ self literal: 0 ofMethod: newMethod.

	"Check if it's an array of length 4"
	self success: ((self fetchClassOf: lit) = (self splObj: ClassArray) 
					and:[(self lengthOf: lit) = 4]).
	successFlag ifFalse:[^nil].

	"Look at the function address in case it has been loaded before"
	addr _ self fetchPointer: 3 ofObject: lit.

	"Check if we have already looked up the function and failed."
	addr = (self integerObjectOf: -1) ifTrue:[
		"Function address was not found in this session,
		Rewrite the mcache entry with a zero primitive index."
		self
			rewriteMethodCacheSel: messageSelector
			class: lkupClass
			primIndex: 0.		
		^self success: false].

	addr _ self positive32BitValueOf: addr.
	successFlag ifFalse: [^ nil].

	"Try to call the function directly"
	addr ~= 0 ifTrue:[^self cCode:' ((int (*) (void)) addr) ()' 
							inSmalltalk:[self callExternalPrimitive: addr]].

	"Clean up session id and function address"
	self storeInteger: 2 ofObject: lit withValue: 0.
	self storeInteger: 3 ofObject: lit withValue: 0.

	"The function has not been loaded yet. 
	Fetch module and function name."
	moduleName _ self fetchPointer: 0 ofObject: lit.
	moduleName = nilObj ifTrue:[
		moduleLength _ 0.
	] ifFalse:[
		self success: (self isBytes: moduleName).
		moduleLength _ self lengthOf: moduleName.
	].

	functionName _ self fetchPointer: 1 ofObject: lit.
	self success: (self isBytes: functionName).
	functionLength _ self lengthOf: functionName.
	successFlag ifFalse:[^nil].
	"Backward compatibility:
		Attempt to map any old-style named primitives into the new ones.
		The old ones are exclusively bound into the VM so we don't need
		to check if a module is given."
	addr _ 0. "Addr ~= 0 indicates we have a compat match later"
	moduleLength = 0 ifTrue:[
		"Search the obsolete named primitive table for a match"
		index _ self findObsoleteNamedPrimitive: (self cCoerce: (functionName+4) to: 'char *') length: functionLength.
		"The returned value is the index into the obsolete primitive table.
		If the index is found, use the 'C-style' version of the lookup."
		index < 0 ifFalse:[
			addr _ self ioLoadFunction: (self cCoerce: ((obsoleteNamedPrimitiveTable at: index) at: 2) to: 'char*')
						From: (self cCoerce: ((obsoleteNamedPrimitiveTable at: index) at: 1) to:'char*')]].
	addr = 0 ifTrue:["Only if no compat version was found"
		addr _ self ioLoadExternalFunction: functionName + 4
					OfLength: functionLength 
					FromModule: moduleName + 4
					OfLength: moduleLength.
	].

	self success: addr ~= 0.
	"Store the address (either actual function address or -1 for failure) back in the literal"
	self pushRemappableOop: lit.
	successFlag
		ifTrue:[functionAddress _ self positive32BitIntegerFor: addr]
		ifFalse:[functionAddress _ self integerObjectOf: -1].
	lit _ self popRemappableOop.
	self storePointer: 3 ofObject: lit withValue: functionAddress.

	"If the function has been successfully loaded process it"
	(successFlag and:[addr ~= 0])
		ifTrue:[^self cCode:' ((int (*) (void)) addr) ()'
					inSmalltalk:[self callExternalPrimitive: addr]]
		ifFalse:["Otherwise rewrite the primitive index"
			self
				rewriteMethodCacheSel: messageSelector
				class: lkupClass
				primIndex: 0].