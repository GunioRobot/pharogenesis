rotateScalePrep
	"Make a source that is the paintingForm.  Work from that.  3/26/97 tk"

	| newBox |
	action == #scaleOrRotate ifTrue: [^ self].	"Already doing it"
	paintingForm width > 120 
		ifTrue: [newBox _ paintingForm rectangleEnclosingPixelsNotOfColor: Color transparent.
			"minimum size"
			newBox _ newBox insetBy: 
				((18 - newBox width max: 0)//2) @ ((18 - newBox height max: 0)//2) * -1]
		ifFalse: [newBox _ paintingForm boundingBox].
	newBox _ newBox expandBy: 1.
	buff _ Form extent: newBox extent depth: paintingForm depth.
	buff offset: newBox center - paintingForm center.
	buff copyBits: newBox from: paintingForm at: 0@0 
		clippingBox: buff boundingBox rule: Form over fillColor: nil.
	"Could just run up owner chain asking colorUsed, but may not be embedded"
	cumRot _ 0.0.  cumMag _ 1.0.	"start over"
	action _ #scaleOrRotate.		"Only changed by mouseDown with tool in paint area"