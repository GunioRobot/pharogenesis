sourceMap
	"Answer a SortedCollection of associations of the form: pc (byte offset in me) -> sourceRange (an Interval) in source text."

	| methNode |
	methNode _ self.
	sourceText ifNil: [
		"No source, use decompile string as source to map from"
		methNode _ self parserClass new
			parse: self decompileString
			class: self methodClass
	].
	methNode generateNative: #(0 0 0 0).  "set bytecodes to map to"
	^ methNode encoder sourceMap