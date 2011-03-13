setExpandBoxBalloonText
	"Set the expand box balloon help text as appropriate."

	expandBox ifNil: [^self].
	self unexpandedFrame
		ifNil: [expandBox setBalloonText: 'expand to full screen' translated]
		ifNotNil: [expandBox setBalloonText: 'contract to original size' translated]