color: colorSpec
	"Set the pen to the Nth color (wraps), or to an explicit color.  "
	colorSpec isInteger
		ifTrue: [destForm depth=1 ifTrue: [^ self fillColor: Color black].
				"spread colors out in randomish fashion"
				self fillColor: (Colors atWrap: colorSpec*9)]
		ifFalse: [self fillColor: colorSpec].	"arg must be a color already"