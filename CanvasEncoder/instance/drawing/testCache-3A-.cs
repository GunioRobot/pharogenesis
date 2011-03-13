testCache: anObject

	| firstFree cachedObject newEntry |

	cachingEnabled ifFalse: [
		cachedObjects _ nil.
		^nil
	].
	cachedObjects ifNil: [
		cachedObjects _ (1 to: 100) collect: [ :x | {WeakArray new: 1. nil. nil. nil}].
	].
	self purgeCache.
	firstFree _ nil.
	cachedObjects withIndexDo: [ :each :index |
		cachedObject _ each first first.
		firstFree ifNil: [cachedObject ifNil: [firstFree _ index]].
		cachedObject == anObject ifTrue: [
			each at: 2 put: (each at: 2) + 1.
			^{index. false. each}
		].
	].
	firstFree ifNil: [^nil].
	newEntry _ {
		WeakArray with: anObject.
		1.
		Time millisecondClockValue.
		nil.
	}.
	cachedObjects at: firstFree put: newEntry.
	^{firstFree. true. newEntry}
