testForNode: targetNode andDo: aBlock

	targetNode == parseNode ifTrue: [aBlock value: self].
	self submorphsDo: [ :each | 
		(each isKindOf: SyntaxMorph) ifTrue: [
			each testForNode: targetNode andDo: aBlock
		].
	].