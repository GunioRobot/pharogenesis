soundStillDownEvt: evt morph: b

	| y pct |

	soundSlider ifNil: [^self].
	y _ evt hand position y.
	(y between: soundSlider top and: soundSlider bottom) ifTrue: [
		pct _ (soundSlider bottom - y) asFloat / soundSlider height.
		self setSoundVolume: pct.
		soundSlider firstSubmorph top: y - 5.
	]. 
