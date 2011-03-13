labelArray: labelArray lines: lineArray
	"Answer an instance of me whose items are in anArray, with lines drawn  after each item indexed by anArray.  2/1/96 sw"

	| aStream |
	labelArray size == 0 ifTrue:
		[self error: 'Menu must not be zero size'].
	aStream _ WriteStream on: (String new: 40).
	labelArray doWithIndex: [:anitem :anIndex | 
		aStream nextPutAll: anitem.
		anIndex ~~ labelArray size
			ifTrue: [aStream cr]].
	^ self labels: aStream contents lines: lineArray

"(PopUpMenu labelArray: #('frog' 'and' 'toad') lines: #()) startUp"