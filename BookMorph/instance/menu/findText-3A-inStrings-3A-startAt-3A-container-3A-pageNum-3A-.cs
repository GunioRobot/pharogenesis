findText: keys inStrings: rawStrings	startAt: startIndex container: oldContainer pageNum: pageNum
	"Call once to search a page of the book.  Return true if found and highlight the text.  oldContainer should be NIL.  
	(oldContainer is only non-nil when (1) doing a 'search again' and (2) the page is in memory and (3) keys has just one element.  oldContainer is a TextMorph.)"

	| good thisWord index insideOf place container start wasIn strings |
	good _ true.
	start _ startIndex.
	strings _ oldContainer ifNil: [rawStrings]	"normal case"
		ifNotNil: [(pages at: pageNum) isInMemory 
					ifFalse: [rawStrings]
					ifTrue: [(pages at: pageNum) allStringsAfter: oldContainer]].
	keys do: [:searchString | "each key"
		good ifTrue: [thisWord _ false.
			strings do: [:longString |
				(index _ longString findString: searchString startingAt: start 
					caseSensitive: false) > 0 ifTrue: [
						thisWord not & (searchString == (keys at: 1)) ifTrue: [
							insideOf _ longString. place _ index].
						thisWord _ true].
				start _ 1].	"only first key on first container"
			good _ thisWord]].
	good ifTrue: ["all are on this page"
		wasIn _ (pages at: pageNum) isInMemory.
		self goToPage: pageNum.
		wasIn ifFalse: ["search again, on the real current text.  Know page is in."
			^ self findText: keys 
				inStrings: ((pages at: pageNum) allStringsAfter: nil) "recompute"	
				startAt: startIndex container: oldContainer 
				pageNum: pageNum]].
	good ifTrue: ["have the exact string object"
		(container _ oldContainer)
			ifNil: [container _ self highlightText: (keys at: 1) at: place in: insideOf]
			ifNotNil: [
				container userString == insideOf 
					ifFalse: [
						container _ self highlightText: (keys at: 1) at: place 
							in: insideOf]
					ifTrue: [(container isKindOf: TextMorph) ifTrue: [
						container editor selectFrom: place to: 
								(keys at: 1) size - 1 + place.
						container changed].
						]].
		self setProperty: #searchContainer toValue: container.
		self setProperty: #searchOffset toValue: place.
		self setProperty: #searchKey toValue: keys.		"override later"
		^ true].
	^ false