makeMeVisible

	| newLoc portRect |
	((Display boundingBox insetBy: (0@0 corner: self labelHeight asPoint))
		containsPoint: self displayBox topLeft) ifTrue: [^ self "OK -- my top left is visible"].

	"window not on screen (probably due to reframe) -- move it now"
	newLoc _ self isCollapsed
		ifTrue: [RealEstateAgent assignCollapsePointFor: self]
		ifFalse: [(RealEstateAgent initialFrameFor: self) topLeft].
	portRect _ newLoc + self labelOffset
				extent: self windowBox extent - self labelOffset.
	self resizeTo: portRect.
	self setLabelRegion.
