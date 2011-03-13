treePrintOn: aStream tabs: tabs thisTab: myTab
	total: total tallyExact: isExact orThreshold: threshold
	| sons sonTab |
	tabs do: [:tab | aStream nextPutAll: tab].
	tabs size > 0 ifTrue: [self printOn: aStream total: total tallyExact: isExact].
	sons _ isExact
		ifTrue: [receivers]
		ifFalse: [self sonsOver: threshold].
	sons isEmpty ifFalse:
		[tabs addLast: myTab.
		sons _ sons asSortedCollection.
		(1 to: sons size) do: 
			[:i |
			sonTab _ i < sons size ifTrue: ['  |'] ifFalse: ['  '].
			(sons at: i) treePrintOn: aStream
				tabs: (tabs size < 18
					ifTrue: [tabs]
					ifFalse: [(tabs select: [:x | x = '[']) copyWith: '['])
				thisTab: sonTab total: total
				tallyExact: isExact orThreshold: threshold].
		tabs removeLast]