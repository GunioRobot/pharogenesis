isContext: oop header: hdr
	"NOTE: anOop is assumed not to be an integer"
	| ccIndex theClass |
	self inline: true.
	ccIndex _ (hdr >> 12) bitAnd: 16r1F.
	ccIndex = 0
		ifTrue: [theClass _ (self classHeader: oop) bitAnd: AllButTypeMask]
		ifFalse: ["look up compact class"
				theClass _ self fetchPointer: ccIndex - 1 ofObject: (self splObj: CompactClasses)].
	^ theClass = (self splObj: ClassMethodContext) or: [theClass = (self splObj: ClassBlockContext)]
