showStats: queueName from: aCollection

	| xx answer prevTime currTime |

	prevTime _ nil.
	answer _ String streamContents: [ :s | 
		s nextPutAll: (aCollection last first - aCollection first first) asStringWithCommas,' ms';cr;cr.
		aCollection withIndexDo: [ :each :index | 
			(queueName == #allStats or: [queueName == each last]) ifTrue: [
				currTime _ each first.
				xx _ currTime printString.
				prevTime ifNil: [prevTime _ currTime].
				s nextPutAll: index printString,'.  ',
					(xx allButLast: 3),'.',(xx last: 3),' ',(currTime - prevTime) printString,' '.
				s nextPutAll: each allButFirst printString; cr.
				prevTime _ currTime.
			].
		]
	].
	StringHolder new 
		contents: answer;
		openLabel: queueName