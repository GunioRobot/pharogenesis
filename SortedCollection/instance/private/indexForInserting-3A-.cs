indexForInserting: newObject

	| index low high |
	low _ firstIndex.
	high _ lastIndex.
	sortBlock isNil
		ifTrue: [[index _ high + low // 2.  low > high]
			whileFalse: 
				[((array at: index) <= newObject)
					ifTrue: [low _ index + 1]
					ifFalse: [high _ index - 1]]]
		ifFalse: [[index _ high + low // 2.  low > high]
			whileFalse: 
				[(sortBlock value: (array at: index) value: newObject)
					ifTrue: [low _ index + 1]
					ifFalse: [high _ index - 1]]].
	^low