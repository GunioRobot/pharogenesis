removeFirstLinkOfList: aList
	"Remove the first process from the given linked list."

	| first last next |
	first _ self fetchPointer: FirstLinkIndex ofObject: aList.
	last  _ self fetchPointer: LastLinkIndex ofObject: aList.
	first = last ifTrue: [
		self storePointer: FirstLinkIndex ofObject: aList withValue: nilObj.
		self storePointer:  LastLinkIndex ofObject: aList withValue: nilObj.
	] ifFalse: [
		next _ self fetchPointer: NextLinkIndex ofObject: first.
		self storePointer: FirstLinkIndex ofObject: aList withValue: next.
	].
	self storePointer: NextLinkIndex ofObject: first withValue: nilObj.
	^ first