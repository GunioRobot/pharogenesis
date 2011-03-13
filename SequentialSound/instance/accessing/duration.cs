duration
	"Answer the duration of this sound in seconds."

	"7 dec 2000 - handle compressed sounds. better way??"

	| dur |
	dur := 0.
	sounds do: [:snd | dur := dur + snd asSound duration].
	^ dur
