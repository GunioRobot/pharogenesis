showSliderFeedback: aString

	| feedBack |

	feedBack _ self 
		valueOfProperty: #sliderFeedback 
		ifAbsent: [
			feedBack _ AlignmentMorph newRow
				hResizing: #shrinkWrap;
				vResizing: #shrinkWrap;
				color: (Color yellow" alpha: 0.6");
				addMorph: (
					TextMorph new 
						contents: '?';
						beAllFont: ((TextStyle default fontOfSize: 24) emphasized: 1)
				).
			self setProperty: #sliderFeedback toValue: feedBack.
			feedBack
		].
	aString ifNotNil: [
		feedBack firstSubmorph contents: aString asString.
		feedBack world ifNil: [feedBack openInWorld].
	].
	^feedBack