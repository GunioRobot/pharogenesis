loadPointShortAt: index from: shortArray
	"Load the short value from the given index in shortArray"
	self returnTypeC:'short'.
	^(self cCoerce: shortArray to: 'short *') at: index