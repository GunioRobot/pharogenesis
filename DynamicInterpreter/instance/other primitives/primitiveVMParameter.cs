primitiveVMParameter
	"Behaviour depends on argument count:
		0 args:	return an Array of VM parameter values;
		1 arg:	return the indicated VM parameter;
		2 args:	set the VM indicated parameter, or interrogate VM table.
	VM parameters are numbered as follows:
		1	end of old-space (0-based, read-only)
		2	end of young-space (read-only)
		3	end of memory (read-only)
		4	allocationCount (read-only)
		5	allocations between GCs (read-write)
		6	survivor count tenuring threshold (read-write)
		7	full GCs since startup (read-only)
		8	total milliseconds in full GCs since startup (read-only)
		9	incremental GCs since startup (read-only)
		10	total milliseconds in incremental GCs since startup (read-only)
		11	tenures of surving objects since startup (read-only)
	and to be implemented Real Soon Now...
		12	number of methods translated (read-only)
		13*	(flag) enable/disable translation time recording -- 0 means 'disabled' (read-write)
		14*	total milliseconds in translation since startup (optional; read-only)
		15	total number of method cache misses	 (read-only)	
		16	total number of method cache hits (read-only)
		17*	total number of inline cache hits (read-only)
		18	inline cache over-size method rejection count (read-only)
		19	inline cache over-size method limit (read-write)
		20	inline cache link delay (read-write)
		21   root table size (read-only)
		22   root table overflows since startup (read-only)
		(Statistics collection for parameters marked '*' can be disabled at VM generation
		 time to reduce impact on performance.  When disabled these values are always 0.)
	With two arguments, the first of which is negative, return a value from a VM
	internal table.  Tables are indexed from 1, but element 0 will appear to contain
	the size of the table.  VM tables are numbered as follows:
		-1	opcodeTable (contains the opcode addresses for this VM)
	Other stuff that might be interesting:
		-	current root table size
		-	number of root table overflows"
	"Note: Thanks to Ian Piumarta for this primitive."

	| mem paramsArraySize result arg index |
	mem _ self cCoerce: memory to: 'int'.
	argumentCount = 0 ifTrue: [
		paramsArraySize _ 22.
		result _ self instantiateClass: (self splObj: ClassArray) indexableSize: paramsArraySize.
		0 to: paramsArraySize - 1 do:
			[:i | self storeWord: i ofObject: result withValue: (self integerObjectOf: 0)].
		self storeWord: 0	ofObject: result withValue: (self integerObjectOf: youngStart - mem).
		self storeWord: 1		ofObject: result withValue: (self integerObjectOf: freeBlock - mem).
		self storeWord: 2	ofObject: result withValue: (self integerObjectOf: endOfMemory - mem).
		self storeWord: 3	ofObject: result withValue: (self integerObjectOf: allocationCount).
		self storeWord: 4	ofObject: result withValue: (self integerObjectOf: allocationsBetweenGCs).
		self storeWord: 5	ofObject: result withValue: (self integerObjectOf: tenuringThreshold).
		self storeWord: 6	ofObject: result withValue: (self integerObjectOf: statFullGCs).
		self storeWord: 7	ofObject: result withValue: (self integerObjectOf: statFullGCMSecs).
		self storeWord: 8	ofObject: result withValue: (self integerObjectOf: statIncrGCs).
		self storeWord: 9	ofObject: result withValue: (self integerObjectOf: statIncrGCMSecs).
		self storeWord: 10	ofObject: result withValue: (self integerObjectOf: statTenures).
		self storeWord: 14	ofObject: result withValue: (self integerObjectOf: statMethodCacheMisses).
		self storeWord: 15	ofObject: result withValue: (self integerObjectOf: statMethodCacheHits).
		self storeWord: 16	ofObject: result withValue: (self integerObjectOf: statInlineCacheHits).
		self storeWord: 18	ofObject: result withValue: (self integerObjectOf: inlineCacheLimit).
		self storeWord: 20	ofObject: result withValue: (self integerObjectOf: rootTableCount).
		self storeWord: 21	ofObject: result withValue: (self integerObjectOf: statRootTableOverflows).
		self pop: 1 thenPush: result.
		^nil].
	arg _ self stackTop.
	(self isIntegerObject: arg) ifFalse: [^self primitiveFail].
	arg _ self integerValueOf: arg.
	argumentCount = 1 ifTrue: [	"read VM parameter"
		(arg < 1 or: [arg > 19]) ifTrue: [^self primitiveFail].
		arg = 1		ifTrue: [result _ youngStart - mem].
		arg = 2		ifTrue: [result _ freeBlock - mem].
		arg = 3		ifTrue: [result _ endOfMemory - mem].
		arg = 4		ifTrue: [result _ allocationCount].
		arg = 5		ifTrue: [result _ allocationsBetweenGCs].
		arg = 6		ifTrue: [result _ tenuringThreshold].
		arg = 7		ifTrue: [result _ statFullGCs].
		arg = 8		ifTrue: [result _ statFullGCMSecs].
		arg = 9		ifTrue: [result _ statIncrGCs].
		arg = 10		ifTrue: [result _ statIncrGCMSecs].
		arg = 11		ifTrue: [result _ statTenures].
		arg = 12		ifTrue: [result _ statTranslationCount.].
		arg = 13		ifTrue: [^self primitiveFail].
		arg = 14		ifTrue: [^self primitiveFail].
		arg = 15		ifTrue: ["result _ statMethodCacheMisses."  ^self primitiveFail].
		arg = 16		ifTrue: ["result _ statMethodCacheHits."  ^self primitiveFail].
		arg = 17		ifTrue: ["result _ statInlineCacheHits."  ^self primitiveFail].
		arg = 18		ifTrue: [^self primitiveFail].
		arg = 19		ifTrue: [result _ inlineCacheLimit].
		arg = 20		ifTrue: [^self primitiveFail].
		arg = 21		ifTrue: [result _ rootTableCount].
		arg = 22		ifTrue: [result _ statRootTableOverflows].
		self pop: 2 thenPush: (self integerObjectOf: result).
		^nil].
	argumentCount = 2 ifFalse: [^self primitiveFail].
	index _ self stackValue: 1.
	(self isIntegerObject: index) ifFalse: [^self primitiveFail].
	index _ self integerValueOf: index.
	index = 0 ifTrue: [^self primitiveFail].
	index > 0 ifTrue: [			"write VM parameter"
		successFlag _ false.
		index = 5	ifTrue: [result _ allocationsBetweenGCs.  allocationsBetweenGCs _ arg.  successFlag _ true.].
		index = 6	ifTrue: [result _ tenuringThreshold.  tenuringThreshold _ arg.  successFlag _ true.].
		index = 19	ifTrue: [result _ inlineCacheLimit.  inlineCacheLimit _ arg.  successFlag _ true.].
		successFlag ifFalse: [^nil].
		self pop: 3 thenPush: (self integerObjectOf: result).	"answer previous value"
		^nil.
	] ifFalse: [					"interrogate VM table"
		arg < 0 ifTrue: [^self primitiveFail].
		index = -1 ifTrue: [	"opcodeTable"
			arg > OpcodeTableSize ifTrue: [^self primitiveFail].
			arg = 0	
				ifTrue: [result _ self integerObjectOf: OpcodeTableSize]
				ifFalse: [result _ opcodeTable at: arg].	"Note: this is already an integer object"
			self pop: 3 thenPush: result.
			^nil.
		].
		"self primitiveFail -- unknown table"
	].
	self primitiveFail.
