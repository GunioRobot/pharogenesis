newObjectHash
	"Answer a new 16-bit pseudo-random number for use as an identity hash."

	lastHash _ 13849 + (27181 * lastHash) bitAnd: 65535.
	^ lastHash
