makeElapsedTimeDisplay

	elapsedTimeDisplay _ LedTimerMorph new
		digits: 3;
		extent: (3*10@15).
	^self wrapPanel: elapsedTimeDisplay label: 'Elapsed Time: '