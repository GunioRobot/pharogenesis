extent: aPoint 
	"Set the receiver's extent to value provided. Respect my minimumExtent."

	| newExtent w|
	newExtent := self isCollapsed
		ifTrue: [aPoint max: (self labelWidgetAllowance @ 0)]
		ifFalse: [aPoint max: self minimumExtent].
	newExtent = self extent ifTrue: [^ self].

	isCollapsed
		ifTrue: [super extent: newExtent x @ self labelHeight]
		ifFalse: [super extent: newExtent].
	isCollapsed
		ifTrue: [collapsedFrame := self bounds]
		ifFalse: [fullFrame := self bounds].
	(self isCollapsed or: [label isNil]) "shrink the label if insufficient space"
		ifFalse: [label minWidth: nil.
				label fitContents.
				w := (label width min: bounds width - labelWidgetAllowance).
				label setWidth: w; minWidth: w.
				label align: label bounds topCenter with: bounds topCenter + (0@borderWidth).
				collapsedFrame ifNotNil:
					[collapsedFrame := collapsedFrame withWidth: label width + labelWidgetAllowance]].
	self theme windowExtentChangedFor: self