valuesInclude: aNumber
	"Private - answer whether or not aNumber is one of the enumerated values in this interval."

	| val |
	val _ (aNumber - self first) asFloat / self increment.
	^ val fractionPart abs < (step * 1.0e-10)