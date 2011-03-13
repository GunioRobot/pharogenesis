altSpecialCursor3: aColor
	| f box |
	"a bulls-eye pattern in this color"
	f _ Form extent: 32@32 depth: 32.
	f offset: (f extent // 2) negated.
	box _ f boundingBox.
	[ box width > 0] whileTrue: [
		f fill: box rule: Form over fillColor: aColor.
		f fill: (box insetBy: 2) rule: Form over fillColor: Color transparent.
		box _ box insetBy: 4.
	].
	^f
