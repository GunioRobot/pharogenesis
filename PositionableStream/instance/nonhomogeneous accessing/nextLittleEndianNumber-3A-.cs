nextLittleEndianNumber: n 
	"Answer the next n bytes as a positive Integer or LargePositiveInteger, where the bytes are ordered from least significant to most significant."

	| bytes s |
	bytes _ self next: n.
	s _ 0.
	n to: 1 by: -1 do: [:i | s _ (s bitShift: 8) bitOr: (bytes at: i)].
	^ s
