recycleContextIfPossible: cntxOop methodContextClass: methodCntxClass
	"If possible, save the given context on a list of free contexts to be recycled."
	"Note: The context is not marked free, so it can be reused with minimal fuss. It's fields are nil-ed out when it is re-used. The recycled context lists are cleared at every garbage collect."
	"Note: This code was found to be critical to good send/return speed, so it has been ruthlessly hand-tuned."

	| cntxHeader ccField isMethodCntx |
	self inline: true.
	"only recycle young contexts (which should be most of them)"
	cntxOop >= youngStart ifTrue: [
		"is the context of class methodCntxClass?"
		cntxHeader _ self baseHeader: cntxOop.
		ccField _ cntxHeader bitAnd: 16r1F000.
		ccField = 0 ifTrue: [
			isMethodCntx _ ((self classHeader: cntxOop) bitAnd: AllButTypeMask) = methodCntxClass.
		] ifFalse: [
			"compare ccField with compact class bits from format word of methodCntxClass"
			isMethodCntx _ ccField = ((self formatOfClass: methodCntxClass) bitAnd: 16r1F000).
		].

		isMethodCntx ifTrue: [
			"Note: The following test depends on the format of object headers
			 and the fact that both small and large contexts are small enough
			 for their size to be encoded in the base object header. If these
			 assumptions is false, contexts won't be recycled properly, but the
			 code should not break."

			(cntxHeader bitAnd: 16rFC) = SmallContextSize ifTrue: [
				self storePointerUnchecked: 0 ofObject: cntxOop withValue: freeSmallContexts.
				freeSmallContexts _ cntxOop.	
			] ifFalse: [
				self storePointerUnchecked: 0 ofObject: cntxOop withValue: freeLargeContexts.
				freeLargeContexts _ cntxOop.	
			].
		].
	].
