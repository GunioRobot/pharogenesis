reversed
	"Answer a copy of the receiver with element order reversed."
	| reversal strm |
	reversal _ self species new: self size.
	strm _ WriteStream on: reversal.
	self reverseDo: [:elem | strm nextPut: elem].
	^ reversal
" 'frog' reversed "