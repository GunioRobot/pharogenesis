sufficientSpaceAfterGC: minFree
	"Return true if there is enough free space after doing a garbage collection. If not, signal that space is low."

	self inline: false.
	self incrementalGC.  "try to recover some space"
	(self sizeOfFree: freeBlock) < minFree ifTrue: [
		signalLowSpace ifTrue: [ ^ false ].  "give up; problem is already noted"
		self fullGC.  "try harder"
		"for stability, require more free space after doing an expensive full GC"
		(self sizeOfFree: freeBlock) < (minFree + 15000) ifTrue: [ ^ false ].  "still not enough"
	].
	^ true