trimAndNormalize: aSoundBuffer
	"Trim leading and trailing silence and normalize the sound level of the given samples."

	| lastSampleIndex maxLevel v threshold startI endI adjust count result |
	"skip the sound of the terminating mouse click..."
	lastSampleIndex _ (aSoundBuffer monoSampleCount - (samplingRate // 10)) max: 1.

	"find maximum level"
	maxLevel _ 0.

	1 to: lastSampleIndex do: [:i |
		v _ aSoundBuffer at: i.
		v < 0 ifTrue: [v _ 0 - v].
		v > maxLevel ifTrue: [maxLevel _ v]].

	"find indices of start and end"
	threshold _ (0.1 * maxLevel) asInteger.
	startI _ 1.
	[(aSoundBuffer at: startI) < threshold]
		whileTrue: [startI _ startI + 1].  "scan for starting point"
	endI _ lastSampleIndex.
	[(aSoundBuffer at: endI) < threshold]
		whileTrue: [endI _ endI - 1].  "scan for ending point"

	"extend range by a twentieth of a second on both ends"
	startI _ (startI - (samplingRate // 20)) max: 1.
	endI _ (endI + (samplingRate // 20)) min: aSoundBuffer monoSampleCount.

	adjust _ (10000 * (30000 / maxLevel)) asInteger.  "fixed point constant for speed"
	count _ (endI - startI) + 1.
	result _ SoundBuffer newMonoSampleCount: (endI - startI) + 1.
	1 to: count do: [:i |
		v _ (adjust * (aSoundBuffer at: (startI + i - 1))) // 10000.
		result at: i put: v].

	^ result
