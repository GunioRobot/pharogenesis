primitiveEvaporateRate
	"Evaporate the integer values of the source Bitmap at the given rate. The rate is an integer between 0 and 1024, where 1024 is a scale factor of 1.0 (i.e., no evaporation)."

	| patchVarOop rate patchVar sz |
	self export: true.
	self var: 'patchVar' declareC: 'unsigned int *patchVar'.

	patchVarOop _ interpreterProxy stackValue: 1.
	rate _ interpreterProxy stackIntegerValue: 0.
	patchVar _ self checkedUnsignedIntPtrOf: patchVarOop.
	sz _ interpreterProxy stSizeOf: patchVarOop.
	interpreterProxy failed ifTrue: [^ nil].

	0 to: sz - 1 do: [:i |
		patchVar at: i put: (((patchVar at: i) * rate) >> 10)].

	interpreterProxy pop: 2.  "pop args, leave rcvr on stack"
