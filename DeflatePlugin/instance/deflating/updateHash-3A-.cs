updateHash: nextValue
	"Update the running hash value based on the next input byte.
	Return the new updated hash value."
	^((zipHashValue bitShift: DeflateHashShift) bitXor: nextValue) bitAnd: DeflateHashMask.