getTableDirEntry: tagString from: fontData
	"Find the table named tagString in fontData and return a table directory entry for it."
	| nTables pos currentTag tag |
	nTables _ fontData shortAt: 5 bigEndian: true.
	tag _ ByteArray new: 4.
	1 to: 4 do:[:i| tag byteAt: i put: (tagString at: i) asInteger].
	tag _ tag longAt: 1 bigEndian: true.
	pos _ 13.
	1 to: nTables do:[:i|
		currentTag _ fontData longAt: pos bigEndian: true.
		currentTag = tag ifTrue:[^TTFontTableDirEntry on: fontData at: pos].
		pos _ pos+16].
	^nil