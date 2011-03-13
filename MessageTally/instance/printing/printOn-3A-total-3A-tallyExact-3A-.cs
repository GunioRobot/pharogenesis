printOn: aStream total: total tallyExact: isExact
	| aSelector className myTally |
	isExact ifTrue:
		[myTally _ tally.
		receivers == nil
			ifFalse: [receivers do: [:r | myTally _ myTally - r tally]].
		aStream print: myTally; space]
		ifFalse:
		[aStream print: (tally asFloat / total * 100.0 roundTo: 0.1); space].
	receivers == nil
		ifTrue: [aStream nextPutAll: 'primitives'; cr]
		ifFalse: 
			[aSelector _ class selectorAtMethod: method setClass: [:aClass].
			className _ aClass name contractTo: 30.
			aStream nextPutAll: class name;
				nextPutAll: (aClass = class ifTrue: ['>>']
								ifFalse: ['(' , aClass name , ')>>']);
				nextPutAll: (aSelector contractTo: 60-className size); cr]