compactClassAt: ccIndex
	"Index must be between 1 and compactClassArray size. (A zero compact class index in the base header indicate that the class is in the class header word.)"

	| classArray |
	classArray _ self fetchPointer: CompactClasses ofObject: specialObjectsOop.
	^ self fetchPointer: (ccIndex - 1) ofObject: classArray