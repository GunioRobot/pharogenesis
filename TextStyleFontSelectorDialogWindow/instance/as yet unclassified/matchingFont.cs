matchingFont
	"Answer the font that matches the selections."

	|ts fs emp|
	ts := (TextStyle named: self familyName) ifNil: [^TextStyle defaultFont].
	fs := self fontSize ifNil: [ts defaultFont pointSize].
	emp := self isBold
		ifTrue: [TextEmphasis bold emphasisCode]
		ifFalse: [TextEmphasis normal emphasisCode].
	self isItalic
		ifTrue: [emp := emp + TextEmphasis italic emphasisCode].
	self isUnderlined
		ifTrue: [emp := emp + TextEmphasis underlined emphasisCode].
	self isStruckOut
		ifTrue: [emp := emp + TextEmphasis struckOut emphasisCode].
	(ts fontOfPointSize: fs) pointSize ~= fs
		ifTrue: [ts addNewFontSize: fs].
	^(ts fontOfPointSize: fs)
		emphasis: emp