processGlyphRecordFrom: data
	| flags |
	flags := data nextByte.
	flags = 0 ifTrue:[^false].
	self flag: #wrongSpec.
	"From news://forums.macromedia.com/macromedia.open-swf
It is an error in the spec. There can be up to 255 characters in run. The
high bit does not mean anything. The text record type 0 and type 1 is poorly
described. The real format is that all of the info in a 'text record type 1'
is always followed by the info in a 'text record type 2'. Note the high bit
of 'text record type 1' is reserved and should always be zero.
"
	self processGlyphStateChange: flags from: data.
	flags := data nextByte.
	flags = 0 ifTrue:[^false].
	self processGlyphEntries: flags from: data.
	"Old stuff - which is according to the f**cking spec"
	"(flags anyMask: 128) ifTrue:[
		self processGlyphStateChange: flags from: data.
	] ifFalse:[
		self processGlyphEntries: flags from: data.
	]."
	^true