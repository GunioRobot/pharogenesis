testBasicCollect

	| res index |
	index := 0.
	res := self collectionWithoutNilElements  collect: [
		:each | 
		index := index + 1.
		each 
		].
	
	res do:[:each | self assert: (self collectionWithoutNilElements occurrencesOf: each) = (res occurrencesOf: each)].
	self assert: index =  self collectionWithoutNilElements size.
	 