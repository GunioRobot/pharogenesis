logOfLargestPowerOfTwoDividing: aPositiveInteger
	"Answer the base-2 log of the largest power of two that divides the given integer. For example, the largest power of two that divides 24 is 8, whose log base-2 is 3. Do this efficiently even when the given number is a large integer. Assume that the given integer is > 0."
	"DigitalSignatureAlgorithm new largestPowerOfTwoDividing: (32 * 3)"

	| digitIndex power d |
	digitIndex := (1 to: aPositiveInteger digitLength) detect: [:i | (aPositiveInteger digitAt: i) ~= 0].
	power := (digitIndex - 1) * 8.
	d := aPositiveInteger digitAt: digitIndex.
	[d odd] whileFalse: [
		power := power + 1.
		d := d bitShift: -1].
	^ power
