printOn: aStream total: total totalTime: totalTime tallyExact: isExact 
	| aSelector className myTally aClass percentage |
	isExact 
		ifTrue: 
			[myTally := tally.
			receivers == nil 
				ifFalse: [receivers do: [:r | myTally := myTally - r tally]].
			aStream
				print: myTally;
				space]
		ifFalse: 
			[percentage := tally asFloat / total * 100.0 roundTo: 0.1.
			aStream
				print: percentage;
				nextPutAll: '% {';
				print: (percentage * totalTime / 100) rounded;
				nextPutAll: 'ms} '].
	receivers == nil 
		ifTrue: 
			[aStream
				nextPutAll: 'primitives';
				cr]
		ifFalse: 
			[aSelector := class selectorAtMethod: method setClass: [:c | aClass := c].
			className := aClass name contractTo: self maxClassNameSize.
			aStream
				nextPutAll: class name;
				nextPutAll: (aClass = class 
							ifTrue: ['>>']
							ifFalse: ['(' , aClass name , ')>>']);
				nextPutAll: (aSelector 
							contractTo: self maxClassPlusSelectorSize - className size);
				cr]