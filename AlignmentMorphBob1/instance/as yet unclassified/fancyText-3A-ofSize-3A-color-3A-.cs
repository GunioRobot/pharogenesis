fancyText: aString ofSize: pointSize color: aColor

	| answer tm |
	answer _ self inAColumn: {
		tm _ TextMorph new 
			beAllFont: ((TextStyle default fontOfSize: pointSize) emphasized: 1);
			color: aColor;
			contents: aString
	}.
	tm addDropShadow.
	tm shadowPoint: (5@5) + tm bounds center.
	tm lock.
	^answer
