predecessorChanged
	| newStart oldStart |
	newStart _ predecessor == nil
		ifTrue: [1]
		ifFalse: [predecessor lastCharacterIndex + 1].
	(self paragraph adjustedFirstCharacterIndex ~= newStart or: [newStart >= text size])
		ifTrue: [paragraph composeAllStartingAt: newStart.
				self fit]
		ifFalse: ["If the offset to end of text has not changed, just slide"
				oldStart _ self firstCharacterIndex.
				self withSuccessorsDo:
					[:m | m adjustLineIndicesBy: newStart - oldStart]].
