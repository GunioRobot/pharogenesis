primitiveGetTabletParameters
	"Get information on the pen tablet attached to this machine. Fail if there is no tablet. If successful, the result is an array of integers; see the Smalltalk call on this primitive for its interpretation."

	| cursorIndex resultSize result |
	cursorIndex _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		resultSize _ self tabletResultSize.
		result _ self instantiateClass: (self splObj: ClassBitmap) indexableSize: resultSize.
		self success: (self cCode: 'tabletGetParameters(cursorIndex, (int *) (result + 4))')].
	successFlag ifTrue: [
		self pop: 2.  "receiver, cursorIndex"
		self push: result].
