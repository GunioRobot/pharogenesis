pageImage: otherImage at: topLeft corner: corner
	"Produce a page-turning illusion that gradually reveals otherImage
	located at topLeft in this form.  Corner specifies which corner, as
		1=topLeft, 2=topRight, 3=bottomRight, 4=bottomLeft."
	| bb maskForm resultForm delta maskLoc maskRect stepSize cornerSel smallRect |
	stepSize _ 10.
	bb _ otherImage boundingBox.
	resultForm _ self copy: (topLeft extent: bb extent).
	maskForm _ Form extent: ((otherImage width min: otherImage height) + stepSize) asPoint.

	"maskLoc _ starting loc rel to topLeft"
	otherImage width > otherImage height
		ifTrue: ["wide image; motion is horizontal."
				(corner between: 2 and: 3) not ifTrue:
					["motion is to the right"
					delta _ 1@0.
					maskLoc _ bb topLeft - (corner = 1
						ifTrue: [maskForm width@0]
						ifFalse: [maskForm width@stepSize])]
					ifFalse:
					["motion is to the left"
					delta _ -1@0.
					maskLoc _ bb topRight - (corner = 2
						ifTrue: [0@0]
						ifFalse: [0@stepSize])]]
		ifFalse: ["tall image; motion is vertical."
				corner <= 2 ifTrue:
					["motion is downward"
					delta _ 0@1.
					maskLoc _ bb topLeft - (corner = 1
						ifTrue: [0@maskForm height]
						ifFalse: [stepSize@maskForm height])]
					ifFalse:
					["motion is upward"
					delta _ 0@-1.
					maskLoc _ bb bottomLeft - (corner = 3
						ifTrue: [stepSize@0]
						ifFalse: [0@0])]].

	"Build a solid triangle in the mask form"
	(Pen newOnForm: maskForm) do: [:p |
		corner even  "Draw 45-degree line"
			ifTrue: [p place: 0@0; turn: 135; go: maskForm width*3//2]
			ifFalse: [p place: 0@(maskForm height-1); turn: 45; go: maskForm width*3//2]].
	maskForm smear: delta negated distance: maskForm width.
	"Copy the mask to full resolution for speed.  Make it be the reversed
	so that it can be used for ORing in the page-corner color"
	maskForm _ (Form extent: maskForm extent depth: otherImage depth)
		copyBits: maskForm boundingBox from: maskForm at: 0@0
		colorMap: (Bitmap with: 16rFFFFFFFF with: 0).

	"Now move the triangle maskForm across the resultForm selecting the
	triangular part of otherImage to display, and across the resultForm,
	selecting the part of the original image to erase."
	cornerSel _ #(topLeft topRight bottomRight bottomLeft) at: corner.
	1 to: (otherImage width + otherImage height // stepSize)+1 do:
		[:i |		"Determine the affected square"
		maskRect _ (maskLoc extent: maskForm extent) intersect: bb.
		((maskLoc x*delta x) + (maskLoc y*delta y)) < 0 ifTrue:
			[smallRect _ 0@0 extent: (maskRect width min: maskRect height) asPoint.
			maskRect _ smallRect align: (smallRect perform: cornerSel)
								with: (maskRect perform: cornerSel)].

		"AND otherForm with triangle mask, and OR into result"
		resultForm copyBits: bb from: otherImage at: 0@0
				clippingBox: maskRect rule: Form over fillColor: nil.
		resultForm copyBits: maskForm boundingBox from: maskForm at: maskLoc
				clippingBox: maskRect rule: Form erase fillColor: nil.
		resultForm copyBits: maskForm boundingBox from: maskForm at: maskLoc
				clippingBox: maskRect rule: Form under fillColor: Color lightBrown.

		"Now update Display in a single BLT."
		self copyBits: maskRect from: resultForm at: topLeft + maskRect topLeft
				clippingBox: self boundingBox rule: Form over fillColor: nil.
		Smalltalk forceDisplayUpdate.
		maskLoc _ maskLoc + (delta*stepSize)]
"
1 to: 4 do: [:corner | Display pageImage:
				(Form fromDisplay: (10@10 extent: 200@300)) reverse
			at: 10@10 corner: corner]
"
