tangentAt: parameter
	"Return the tangent at the given parametric value along the receiver"
	| in out |
	in _ self tangentAtStart.
	out _ self tangentAtEnd.
	^in + (out - in * parameter)