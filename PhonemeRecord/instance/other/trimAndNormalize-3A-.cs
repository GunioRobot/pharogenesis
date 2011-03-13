trimAndNormalize: aSoundBuffer
	"Trim leading and trailing silence and normalize the sound level of the given samples."

	| lastSampleIndex maxLevel v threshold startI endI adjust count result |
	"skip the sound of the terminating mouse click..."
	lastSampleIndex := (aSoundBuffer monoSampleCount - (samplingRate // 10)) max: 1.

	"find maximum level"
	maxLevel := 0.

	1 to: lastSampleIndex do: [:i |
		v := aSoundBuffer at: i.
		v < 0 ifTrue: [v := 0 - v].
		v > maxLevel ifTrue: [maxLevel := v]].

	"find indices of start and end"
	threshold := (0.1 * maxLevel) asInteger.
	startI := 1.
	[(aSoundBuffer at: startI) < threshold]
		whileTrue: [startI := startI + 1].  "scan for starting point"
	endI := lastSampleIndex.
	[(aSoundBuffer at: endI) < threshold]
		whileTrue: [endI := endI - 1].  "scan for ending point"

	"extend range by a twentieth of a second on both ends"
	startI := (startI - (samplingRate // 20)) max: 1.
	endI := (endI + (samplingRate // 20)) min: aSoundBuffer monoSampleCount.

	adjust := (10000 * (30000 / maxLevel)) asInteger.  "fixed point constant for speed"
	count := (endI - startI) + 1.
	result := SoundBuffer newMonoSampleCount: (endI - startI) + 1.
	1 to: count do: [:i |
		v := (adjust * (aSoundBuffer at: (startI + i - 1))) // 10000.
		result at: i put: v].

	^ result
