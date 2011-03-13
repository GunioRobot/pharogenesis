testBlockNumberingForInjectInto
	"Test that the compiler and CompiledMethod agree on the block numbering of Collection>>inject:into:
	 and that temp names for inject:into: are recorded."
	"self new testBlockNumberingForInjectInto"
	| methodNode method tempRefs |
	methodNode := Parser new
						encoderClass: EncoderForV3PlusClosures;
						parse: (Collection sourceCodeAt: #inject:into:)
						class: Collection.
	method := methodNode generate: #(0 0 0 0).
	tempRefs := methodNode encoder blockExtentsToTempsMap.
	self assert: tempRefs keys = method startpcsToBlockExtents values asSet.
	self assert: ((tempRefs includesKey: (0 to: 6))
				and: [(tempRefs at: (0 to: 6)) hasEqualElements: #(('thisValue' 1) ('binaryBlock' 2) ('nextValue' (3 1)))]).
	self assert: ((tempRefs includesKey: (2 to: 4))
				and: [(tempRefs at: (2 to: 4)) hasEqualElements: #(('each' 1) ('binaryBlock' 2) ('nextValue' (3 1)))])