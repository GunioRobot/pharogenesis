merge: sourceWord with: destinationWord
	| mergeFnwith |
	"Sender warpLoop is too big to include this in-line"
	self var: #mergeFnwith declareC: 'int (*mergeFnwith)(int, int)'.
	mergeFnwith _ self cCoerce: (opTable at: combinationRule+1) to: 'int (*)(int, int)'.
	mergeFnwith.  "null ref for compiler"

	^ self mergeFn: sourceWord with: destinationWord