prepareForUpload
	"The receiver is about to be modified for a texture upload. Bring it's bits in place."
	| bitsSize |
	bits isInteger ifTrue:[^self]. "handled transparently"
	bitsSize _ self bitsSize.
	bits size = bitsSize ifFalse:[bits _ bits class new: bitsSize].
