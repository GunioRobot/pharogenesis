primitiveInstVarsPutFromStack
	"Note:  this primitive has been decommissioned.  It is only here for short-term compatibility with an internal 2.3beta-d image that used this.  It did not save much time and it complicated several things.  Plus Jitter will do it right anyway."
	| rcvr offsetBits |
	rcvr _ self stackValue: argumentCount.
	"Mark dirty so stores below can be unchecked"
	(rcvr < youngStart) ifTrue: [ self beRootIfOld: rcvr ].
	0 to: argumentCount-1 do:
		[:i | (i bitAnd: 3) = 0 ifTrue:
			[offsetBits _ self positive32BitValueOf: (self literal: i//4 ofMethod: newMethod)].
		self storePointerUnchecked: (offsetBits bitAnd: 16rFF) ofObject: rcvr
						withValue: (self stackValue: i).
		offsetBits _ offsetBits >> 8].
	self pop: argumentCount