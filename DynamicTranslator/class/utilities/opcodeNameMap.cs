opcodeNameMap
	"Note: assumes that the opcode set of the running VM corresponds
	to that of the VM implementation in the image."

	| tableSize opAddr opName map |
	map _ IdentityDictionary new.
	tableSize _ Smalltalk vmTable: -1 at: 0.
	1 to: tableSize do: [:i |
		opAddr _ Smalltalk vmTable: -1 at: i.
		opName _ DynamicTranslator opcodeEncodings keyAtValue: i.
		map at: opAddr put: opName].
	^map