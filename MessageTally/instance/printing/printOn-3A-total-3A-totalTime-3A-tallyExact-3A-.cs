printOn: aStream total: total totalTime: totalTime tallyExact: isExact
	| aSelector className myTally aClass percentage |
	isExact
		ifTrue:
			[myTally _ tally.
			receivers == nil
				ifFalse: [receivers do: [:r | myTally _ myTally - r tally]].
			aStream print: myTally; space]
		ifFalse:
			[percentage _ tally asFloat / total * 100.0 roundTo: 0.1.
			aStream
				print: percentage;
				nextPutAll: '% {';
				print: (percentage * totalTime / 100) rounded;
				nextPutAll: 'ms} '].
	receivers == nil
		ifTrue: [aStream nextPutAll: 'primitives'; cr]
		ifFalse: 
			[aSelector _ class selectorAtMethod: method setClass: [:c | aClass _
c].
			className _ aClass name contractTo: 30.
			aStream nextPutAll: class name;
				nextPutAll: (aClass = class ifTrue: ['>>']
								ifFalse: ['(' , aClass name , ')>>']);
				nextPutAll: (aSelector contractTo: 60-className size); cr]