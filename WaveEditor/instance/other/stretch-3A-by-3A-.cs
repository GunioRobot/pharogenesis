stretch: sampleArray by: stretchFactor
	"Return an array consisting of the given samples \stretched in time by the given factor."

	| out end incr i frac index |
	out _ OrderedCollection new: (stretchFactor * sampleArray size) asInteger + 1.
	end _ (sampleArray size - 1) asFloat.
	incr _ 1.0 / stretchFactor.
	i _ 1.0.
	[i < end] whileTrue: [
		frac _ i fractionPart.
		index _ i truncated.
		i _ i + incr.
		out addLast:
			(((1.0 - frac) * (sampleArray at: index)) + (frac * (sampleArray at: index + 1))) rounded].
	^ out asArray
