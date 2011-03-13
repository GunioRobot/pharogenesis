fillWithColor: aColor
	"Fill the receiver's bounding box with the given color.  5/15/96 sw.  Subsequently fixed  by tk to be compatible with changed color definition.  7/31/96 sw: code tightened"

	self fill: self boundingBox fillColor:
		(aColor class == Symbol ifTrue: [Color perform: aColor] ifFalse: [aColor])