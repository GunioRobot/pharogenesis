computePixelRampOfSize: length
	"Compute the pixel ramp in the receiver"
	| bits lastColor lastIndex nextIndex nextColor distance theta lastValue ramp lastWord nextWord step |
	ramp _ colorRamp asSortedCollection:[:a1 :a2| a1 key < a2 key].
	bits _ Bitmap new: length.
	lastColor _ ramp first value.
	lastWord _ lastColor pixelWordForDepth: 32.
	lastIndex _ 0.
	ramp do:[:assoc|
		nextIndex _ (assoc key * length) rounded.
		nextColor _ assoc value.
		nextWord _ nextColor pixelWordForDepth: 32.
		distance _ (nextIndex - lastIndex).
		distance = 0 ifTrue:[distance _ 1].
		step _ 1.0 / distance asFloat.
		theta _ 0.0.
		lastIndex+1 to: nextIndex do:[:i|
			theta _ theta + step.
			"The following is an open-coded version of:
				color _ nextColor alphaMixed: theta with: lastColor.
				bits at: i put: (color scaledPixelValue32).
			"
			bits at: i put: (self scaledAlphaMix: theta of: lastWord with: nextWord).
		].
		lastIndex _ nextIndex.
		lastColor _ nextColor.
		lastWord _ nextWord.
	].
	lastValue _ lastColor scaledPixelValue32.
	lastIndex+1 to: length do:[:i| bits at: i put: lastValue].
	^bits