setLabel: aString
	labelString _ aString.
	label ifNil: [^ self].
	label contents: aString.
	self labelWidgetAllowance.  "Sets it if not already"
	self isCollapsed
		ifTrue: [self extent: (label width + labelWidgetAllowance) @ (self labelHeight + 2)]
		ifFalse: [label fitContents; setWidth: (label width min: bounds width - labelWidgetAllowance).
				label align: label bounds topCenter with: bounds topCenter + (0@borderWidth).
				collapsedFrame ifNotNil:
					[collapsedFrame _ collapsedFrame withWidth: label width + labelWidgetAllowance]]