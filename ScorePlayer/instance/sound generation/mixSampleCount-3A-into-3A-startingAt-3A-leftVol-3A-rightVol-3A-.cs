mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play a number of sounds concurrently. The level of each sound can be set independently for the left and right channels."

	| myLeftVol myRightVol someSoundIsDone pair snd trk left right |
	myLeftVol _ (leftVol * overallVolume) asInteger.
	myRightVol _ (rightVol * overallVolume) asInteger.
	someSoundIsDone _ false.
	1 to: activeSounds size do: [:i |
		pair _ activeSounds at: i.
		snd _ pair at: 1.
		trk _ pair at: 2.
		left _ (myLeftVol * (leftVols at: trk)) // ScaleFactor.
		right _ (myRightVol * (rightVols at: trk)) // ScaleFactor.
		snd samplesRemaining > 0
			ifTrue: [
				snd mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: left rightVol: right]
			ifFalse: [someSoundIsDone _ true]].

	someSoundIsDone ifTrue: [
		activeSounds _ activeSounds select: [:p | p first samplesRemaining > 0]].
