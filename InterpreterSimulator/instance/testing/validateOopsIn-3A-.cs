validateOopsIn: object
	| fieldPtr limit former header | 
	"for each oop in me see if it is legal"
	fieldPtr _ object + BaseHeaderSize.	"first field"
	limit _ object + (self lastPointerOf: object).	"a good field"
	[fieldPtr > limit] whileFalse: [
		former _ self longAt: fieldPtr.
		(self validOop: former) ifFalse: [self halt].
		fieldPtr _ fieldPtr + 4].
	"class"
	header _ self baseHeader: object.
	(header bitAnd: CompactClassMask) = 0 ifTrue: [	
		former _ (self classHeader: object) bitAnd: AllButTypeMask.
		(self validOop: former) ifFalse: [self halt]].