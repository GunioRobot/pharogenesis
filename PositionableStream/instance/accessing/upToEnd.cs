upToEnd
	"Answer a subcollection from the current access position through the last element of the receiver."

	| newStream el |
	newStream _ WriteStream on: (collection species new: 100).
	[(el _ self next) == nil] whileFalse: [ newStream nextPut: el ].
	^ newStream contents