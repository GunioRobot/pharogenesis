computePixelRampOfSize: length
	"Compute the pixel ramp in the receiver"
	| bits lastColor lastIndex nextIndex nextColor distance theta color lastValue ramp |
	ramp _ colorRamp asSortedCollection:[:a1 :a2| a1 key < a2 key].
	bits _ Bitmap new: length.
	lastColor _ ramp first value.
	lastIndex _ 0.
	ramp do:[:assoc|
		nextIndex _ (assoc key * length) rounded.
		nextColor _ assoc value.
		distance _ (nextIndex - lastIndex).
		distance = 0 ifTrue:[distance _ 1].
		lastIndex+1 to: nextIndex do:[:i|
			theta _ (i - lastIndex) asFloat / distance asFloat.
			color _ nextColor alphaMixed: theta with: lastColor.
			bits at: i put: (color scaledPixelValue32).
		].
		lastIndex _ nextIndex.
		lastColor _ nextColor.
	].
	lastValue _ lastColor scaledPixelValue32.
	lastIndex+1 to: length do:[:i| bits at: i put: lastValue].
	^bits