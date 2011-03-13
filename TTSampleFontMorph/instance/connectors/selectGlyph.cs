selectGlyph
	| retval done |
	"Modal glyph selector"
	done _ false.
	self on: #mouseDown send: #selectGlyphBlock:event:from: to: self withValue: [ :glyph | retval _ glyph. done _ true. ].
	self on: #keyStroke send: #value to: [ done _ true ].
	[ done ] whileFalse: [ self world doOneCycle ].
	self on: #mouseDown send: nil to: nil.
	self on: #keyStroke send: nil to: nil.
	^retval