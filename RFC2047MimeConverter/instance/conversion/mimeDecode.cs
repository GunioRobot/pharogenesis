mimeDecode
	"Do conversion reading from mimeStream writing to dataStream. See String>>decodeMimeHeader"

	| c |
	[mimeStream atEnd] whileFalse: [
		c _ mimeStream next.
		c = $=
			ifTrue: [c _ Character value: mimeStream next digitValue * 16
				+ mimeStream next digitValue]
			ifFalse: [c = $_ ifTrue: [c _ $ ]].
		dataStream nextPut: c].
	^ dataStream