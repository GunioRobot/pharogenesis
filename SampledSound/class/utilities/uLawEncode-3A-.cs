uLawEncode: anArray
	"Convert the given array of 16-bit signed samples into a ByteArray of uLaw-encoded 8-bit samples."

	| n out s |
	n _ anArray size.
	out _ ByteArray new: n.
	1 to: n do: [:i |
		s _ anArray at: i.
		s _ s bitShift: -3.  "drop 4 least significant bits"
		s < 0
			ifTrue: [s _ (self uLawEncodeSample: s negated) bitOr: 16r80]
			ifFalse: [s _ (self uLawEncodeSample: s)].
		out at: i put: s].
	^ out
