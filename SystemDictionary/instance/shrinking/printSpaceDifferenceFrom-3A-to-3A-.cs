printSpaceDifferenceFrom: fileName1 to: fileName2
	"For differential results, run printSpaceAnalysis twice with different fileNames,
	then run this method...
		Smalltalk printSpaceAnalysis: 0 on: 'STspace.text1'.
			--- do something that uses space here ---
		Smalltalk printSpaceAnalysis: 0 on: 'STspace.text2'.
		Smalltalk printSpaceDifferenceFrom: 'STspace.text1' to: 'STspace.text2'
"
	| f coll1 coll2 item |
	f _ FileStream oldFileNamed: fileName1.
	coll1 _ OrderedCollection new.
	[f atEnd] whileFalse: [coll1 add: (f upTo: Character cr)].
	f close.
	f _ FileStream oldFileNamed: fileName2.
	coll2 _ OrderedCollection new.
	[f atEnd] whileFalse:
		[item _ (f upTo: Character cr).
		((coll1 includes: item) and: [(item endsWith: 'percent') not])
			ifTrue: [coll1 remove: item]
			ifFalse: [coll2 add: item]].
	f close.
	(StringHolder new contents: (String streamContents: 
			[:s | 
			s nextPutAll: fileName1; cr.
			coll1 do: [:x | s nextPutAll: x; cr].
			s cr; cr.
			s nextPutAll: fileName2; cr.
			coll2 do: [:x | s nextPutAll: x; cr]]))
		openLabel: 'Differential Space Analysis'.
