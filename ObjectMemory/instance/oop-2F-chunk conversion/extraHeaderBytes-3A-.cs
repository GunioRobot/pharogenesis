extraHeaderBytes: oopOrChunk
	"Return the number of extra bytes used by the given object's header."
	"Warning: This method should not be used during marking, when the header type bits of an object may be incorrect."

	| type extra |
	self inline: true.
	type _ self headerType: oopOrChunk.
	type > 1 ifTrue: [
		extra _ 0.  "free chunk (type 2) or 1-word header (type 3); most common"
	] ifFalse: [
		type = 1
			ifTrue: [ extra _ 4.  "2-word header (type 1)" ]
			ifFalse: [ extra _ 8.  "3-word header (type 0)" ].
	].
	^ extra