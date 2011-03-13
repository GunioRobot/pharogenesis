keyUp: key vel: vel
	"Handle a key up event."

	| snd |
	activeSounds copy do: [:entry |
		(entry at: 1) = key ifTrue: [
			snd := entry at: 2.
			snd stopGracefully.
			activeSounds remove: entry]].
