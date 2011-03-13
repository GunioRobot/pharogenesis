remapCompactClasses: mapFakeClassesToReal refStrm: smartRefStream
	| ccArray current fake info |
	"See if our compact classes are compatible with this system.  Convert to what the system already has.  If we are adding a new class, it has already been filed in.  A compact class may not be a root."

	(outPointers at: (outPointers size - 1)) = 1717 ifFalse: [^ true].
	ccArray := outPointers last.
	current := Smalltalk compactClassesArray.
	1 to: ccArray size do: [:ind | 
		(ccArray at: ind) ifNotNil: ["is compact in the segment"
			fake := mapFakeClassesToReal keyAtValue: (current at: ind) ifAbsent: [nil].
			info := self cc: ind new: (ccArray at: ind) current: (current at: ind) 
					fake: fake refStrm: smartRefStream.
			info ifFalse: [^ false]]].
	^ true