sufficientSpaceAfterGC: minFree 
	"Return true if there is enough free space after doing a garbage collection. If not, signal that space is low."
	| growSize |
	self inline: false.

	self incrementalGC. "try to recover some space"

	(self cCoerce: (self sizeOfFree: freeBlock) to: 'unsigned ') < (self cCoerce: minFree to: 'unsigned ')
		ifTrue: [signalLowSpace ifTrue: [^false]. "give up; problem is already noted"
			self fullGC. "try harder"
			"for stability, require more free space after doing an expensive full GC"
			(self cCoerce: (self sizeOfFree: freeBlock) to: 'unsigned ') >= ((self cCoerce: minFree to: 'unsigned ') + 15000) ifTrue: [^ true].

			"still not enough; attempt to grow object memory"
			growSize _ minFree - (self sizeOfFree: freeBlock) + growHeadroom.
			self growObjectMemory: growSize.

			(self cCoerce: (self sizeOfFree: freeBlock) to: 'unsigned ') >= ((self cCoerce: minFree to: 'unsigned ') + 15000) ifTrue: [^true].

			"still not enough"
			^false].
	^true