initialize
	"SampledSound initialize"

	IncrementFractionBits _ 16.
	IncrementScaleFactor _ 2 raisedTo: IncrementFractionBits.
	ScaledIndexOverflow _ 2 raisedTo: 29.  "handle overflow before needing LargePositiveIntegers"
	self useCoffeeCupClink.
	SoundLibrary ifNil: [SoundLibrary _ Dictionary new].
