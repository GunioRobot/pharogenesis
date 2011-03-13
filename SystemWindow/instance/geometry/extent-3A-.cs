extent: aPoint 
	"Set the receiver's extent to value provided. Respect my minimumExtent."

	| newExtent |
	newExtent _ self isCollapsed
		ifTrue: [aPoint]
		ifFalse: [aPoint max: self minimumExtent].
	newExtent = self extent ifTrue: [^ self].

	isCollapsed
		ifTrue: [super extent: newExtent x @ (self labelHeight + 2)]
		ifFalse: [super extent: newExtent].
	isCollapsed
		ifTrue: [collapsedFrame _ self bounds]
		ifFalse: [fullFrame _ self bounds]