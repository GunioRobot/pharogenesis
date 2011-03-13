initialize: aSocket
	socket _ aSocket.
	inBuf _ String new: 1000.
	inBufIndex _ 1.
	inBufLastIndex := 0.

	outBuf _ nil.

	inObjects _ OrderedCollection new.
	outObjects _ OrderedCollection new.
