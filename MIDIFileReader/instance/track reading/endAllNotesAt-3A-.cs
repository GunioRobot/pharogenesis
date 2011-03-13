endAllNotesAt: endTicks
	"End of score; end any notes still sounding."
	"Details: Some MIDI files have missing note-off events, resulting in very long notes. Truncate any such notes encountered."

	| dur |
	activeEvents do: [:e |
		dur _ endTicks - e time.
		dur > maxNoteTicks ifTrue: [dur _ ticksPerQuarter].  "truncate long note"
		e duration: dur].
	activeEvents _ activeEvents species new.
