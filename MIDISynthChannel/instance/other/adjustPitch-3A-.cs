adjustPitch: bend
	"Handle a pitch-bend change."

	| snd pitchAdj centerPitch |
	pitchBend _ bend.
	pitchAdj _ 2.0 raisedTo: (bend asFloat / 8192.0) / 6.0.
	activeSounds copy do: [:entry |
		snd _ entry at: 2.
		centerPitch _ entry at: 3.
		snd pitch: pitchAdj * centerPitch.
		snd internalizeModulationAndRatio].
