lowPassFiltered
	"Answer a simple low-pass filtered copy of this buffer. Assume it is monophonic."

	| sz out last this |
	sz _ self monoSampleCount.
	out _ self clone.
	last _ self at: 1.
	2 to: sz do: [:i |
		this _ self at: i.
		out at: i put: (this + last) // 2.
		last _ this].
	^ out
