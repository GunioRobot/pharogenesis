byteArrayMap
	"return a ByteArray mapping each ascii value to a 1 if that ascii value is in the set, and a 0 if it isn't.
	Intended for use by primitives only. (and comparison)
	This version will answer a subset with only byte characters"
	
	| aMap lowmap |
	aMap := ByteArray new: 256.
	lowmap := map at: 0 ifAbsent: [^aMap].
	lowmap := lowmap copyFrom: 1 to: 8. "Keep first 8*32=256 bits..."
	self bitmap: lowmap do: [:code | aMap at: code + 1 put: 1].
	^aMap