testBecome
	"Become some young things.  AA testBecome    "
	| array list1 list2 p1 p2 p3 p4 |
	array _ self splObj: ClassArray.
	list1 _ self instantiateClass: array indexableSize: 2.
	list2 _ self instantiateClass: array indexableSize: 2.
	p1 _ self instantiateClass: (self splObj: ClassPoint) indexableSize: 0.
	self push: p1.
	self storePointer: 0 ofObject: list1 withValue: p1.
	p2 _ self instantiateClass: (self splObj: ClassPoint) indexableSize: 0.
	self push: p2.
	self storePointer: 1 ofObject: list1 withValue: p2.
	p3 _ self instantiateClass: (self splObj: ClassMessage) indexableSize: 0.
	self push: p3.
	self storePointer: 0 ofObject: list2 withValue: p3.
	p4 _ self instantiateClass: (self splObj: ClassMessage) indexableSize: 0.
	self push: p4.
	self storePointer: 1 ofObject: list2 withValue: p4.
	(self become: list1 with: list2) ifFalse: [self error: 'failed'].
	self popStack = p2 ifFalse: [self halt].
	self popStack = p1 ifFalse: [self halt].
	self popStack = p4 ifFalse: [self halt].
	self popStack = p3 ifFalse: [self halt].
	(self fetchPointer: 0 ofObject: list1) = p3 ifFalse: [self halt].
	(self fetchPointer: 1 ofObject: list1) = p4 ifFalse: [self halt].
	(self fetchPointer: 0 ofObject: list2) = p1 ifFalse: [self halt].
	(self fetchPointer: 1 ofObject: list2) = p2 ifFalse: [self halt].