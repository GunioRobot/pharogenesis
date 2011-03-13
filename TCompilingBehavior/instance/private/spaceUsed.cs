spaceUsed
	"Answer a rough estimate of number of bytes used by this class and its metaclass. Does not include space used by class variables."

	| space method |
	space _ 0.
	self selectorsDo: [:sel |
		space _ space + 16.  "dict and org'n space"
		method _ self compiledMethodAt: sel.
		space _ space + (method size + 6 "hdr + avg pad").
		method literals do: [:lit |
			(lit isMemberOf: Array) ifTrue: [space _ space + ((lit size + 1) * 4)].
			(lit isMemberOf: Float) ifTrue: [space _ space + 12].
			(lit isMemberOf: ByteString) ifTrue: [space _ space + (lit size + 6)].
			(lit isMemberOf: LargeNegativeInteger) ifTrue: [space _ space + ((lit size + 1) * 4)].
			(lit isMemberOf: LargePositiveInteger) ifTrue: [space _ space + ((lit size + 1) * 4)]]].
		^ space