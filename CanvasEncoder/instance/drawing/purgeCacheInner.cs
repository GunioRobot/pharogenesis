purgeCacheInner

	| cachedObject totalSize thisSize |

	cachedObjects ifNil: [^0].
	totalSize _ 0.
	cachedObjects withIndexDo: [ :each :index |
		cachedObject _ each first first.
		cachedObject ifNil: [
			each second ifNotNil: [
				2 to: each size do: [ :j | each at: j put: nil].
				self sendCommand: {
					String with: CanvasEncoder codeReleaseCache.
					self class encodeInteger: index.
				}.
			].
		] ifNotNil: [
			thisSize _ cachedObject depth * cachedObject width * cachedObject height // 8.
			totalSize _ totalSize + thisSize.
		].
	].
	^totalSize
	"---
	newEntry _ {
		WeakArray with: anObject.
		1.
		Time millisecondClockValue.
		nil.
	}.
	---"
