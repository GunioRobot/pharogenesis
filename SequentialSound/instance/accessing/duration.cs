duration
	"Answer the duration of this sound in seconds."

	| dur |
	dur _ 0.
	sounds do: [:snd | dur _ dur + snd duration].
	^ dur
