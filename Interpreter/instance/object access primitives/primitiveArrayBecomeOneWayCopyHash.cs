primitiveArrayBecomeOneWayCopyHash
	"Similar to primitiveArrayBecomeOneWay but accepts a third argument whether to copy
	the receiver's identity hash over the argument's identity hash."

	| copyHashFlag arg rcvr |
	copyHashFlag _ self booleanValueOf: (self stackTop).
	arg _ self stackValue: 1.
	rcvr _ self stackValue: 2.
	self success: (self become: rcvr with: arg twoWay: false copyHash: copyHashFlag).
	successFlag ifTrue: [ self pop: 2 ].