compactClassesArray
	| ccIndexes ind ccArray hdrBits |
	"A copy of the real compactClassesArray, but with only the classes actually used in the segment.  Slow, but OK for export."

	ccIndexes _ Set new.
	ind _ 2. 	"skip version word, first object"
	"go past extra header words"
	(hdrBits _ (segment atPin: ind) bitAnd: 3) = 1 ifTrue: [ind _ ind+1].
	hdrBits = 0 ifTrue: [ind _ ind+2].

	[ccIndexes add: (self compactIndexAt: ind).	"0 if has class field"
	 ind _ self objectAfter: ind.
	 ind > segment size] whileFalse.
	ccArray _ Smalltalk compactClassesArray clone.
	1 to: ccArray size do: [:ii | "only the ones we use"
		(ccIndexes includes: ii) ifFalse: [ccArray at: ii put: nil]].
	^ ccArray