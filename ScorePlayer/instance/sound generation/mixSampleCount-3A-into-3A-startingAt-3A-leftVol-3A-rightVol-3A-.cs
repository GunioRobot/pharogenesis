mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: leftVol rightVol: rightVol
	"Play a number of sounds concurrently. The level of each sound can be set independently for the left and right channels."

	| someSoundIsDone pair snd trk left right |
	someSoundIsDone _ false.
	1 to: activeSounds size do: [:i |
		pair _ activeSounds at: i.
		snd _ pair at: 1.
		trk _ pair at: 2.
		left _ (leftVol * (leftVols at: trk)) // ScaleFactor.
		right _ (rightVol * (rightVols at: trk)) // ScaleFactor.
		snd samplesRemaining > 0
			ifTrue: [
				snd mixSampleCount: n into: aSoundBuffer startingAt: startIndex leftVol: left rightVol: right]
			ifFalse: [someSoundIsDone _ true]].

	someSoundIsDone ifTrue: [
		activeSounds _ activeSounds select: [:p | p first samplesRemaining > 0]].
