scanForStartThreshold: threshold dcOffset: dcOffset minDur: duration startingAt: startPlace
	"Beginning at startPlace, this routine will find the first sound that exceeds threshold, such that if you look duration samples later you will find another sound over threshold within the following block of duration samples.
	Return the place that is duration samples prior to that first sound.
	If no sound is found, return endPlace."

	| soundPlace lookPlace nextSoundPlace thirdPlace |
	soundPlace _ self firstSampleOverThreshold: threshold dcOffset: dcOffset
					startingAt: startPlace.
	[soundPlace = self endPlace ifTrue: [^ soundPlace].
	"Found a sound -- look duration later"
	lookPlace _ self place: soundPlace plus: duration.
	nextSoundPlace _ self firstSampleOverThreshold: threshold dcOffset: dcOffset
					startingAt: lookPlace.
	thirdPlace _ self place: lookPlace plus: duration.
	nextSoundPlace first < thirdPlace first
		or: [nextSoundPlace first = thirdPlace first
			and: [nextSoundPlace second < thirdPlace second]]]
		whileFalse: [soundPlace _ nextSoundPlace].

	"Yes, there is sound in the next interval as well"
	^ self place: soundPlace plus: 0-duration
