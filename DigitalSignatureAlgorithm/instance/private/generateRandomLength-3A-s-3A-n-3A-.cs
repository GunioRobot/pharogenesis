generateRandomLength: bitLength s: s n: n
	"Answer a random number of bitLength bits generated using the secure hash algorithm."

	| sha out count extraBits v |
	sha _ SecureHashAlgorithm new.
	out _ 0.
	count _ (bitLength // 160).
	extraBits _ bitLength - (count * 160).
	0 to: count do: [:k |
		v _ sha hashInteger: (s + n + k).
		k = count ifTrue: [
			v _ v - ((v >> extraBits) << extraBits)].
		out _ out bitOr: (v bitShift: (160 * k))].
	^ out
