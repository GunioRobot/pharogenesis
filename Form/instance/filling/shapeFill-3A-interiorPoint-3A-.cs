shapeFill: aColor interiorPoint: interiorPoint
	"Identify the shape (region of identical color) at interiorPoint,
	and then fill that shape with the new color, aColor
	: modified di's original method such that it returns the bwForm, for potential use by the caller"

	| bwForm interiorPixVal map ppd color ind |
	depth = 1 ifTrue:
		[^ self shapeFill: aColor
			seedBlock: [:form | form pixelValueAt: interiorPoint put: 1]].

	"First map this form into a B/W form with 0's in the interior region."
	interiorPixVal _ self pixelValueAt: interiorPoint.
	bwForm _ Form extent: self extent.
	map _ Bitmap new: (1 bitShift: (depth min: 12)).  "Not calling newColorMap.  All 
			non-foreground go to 0.  Length is 2 to 4096."
	ppd _ depth.	"256 long color map in depth 8 is not one of the following cases"
	3 to: 5 do: [:bitsPerColor | 
		(2 raisedTo: bitsPerColor*3) = map size 
			ifTrue: [ppd _ bitsPerColor*3]].	"ready for longer maps than 512"

	ppd <= 8
		ifTrue: [map at: interiorPixVal+1 put: 1]
		ifFalse: [interiorPixVal = 0 
			ifFalse: [color _ Color colorFromPixelValue: interiorPixVal depth: depth.
				ind _ color pixelValueForDepth: ppd.
				map at: ind+1 put: 1]
			ifTrue: [map at: 1 put: 1]].
	bwForm copyBits: self boundingBox from: self at: 0@0 colorMap: map.
		"bwForm _ self makeBWForm: interiorColor."	"not work for two whites"
	bwForm reverse.  "Make interior region be 0's"

	"Now fill the interior region and return that shape"
	bwForm _ bwForm findShapeAroundSeedBlock:
					[:form | form pixelValueAt: interiorPoint put: 1].

	"Finally use that shape as a mask to flood the region with color"
	((BitBlt current destForm: self sourceForm: bwForm 
		fillColor: nil
		combinationRule: Form erase1bitShape	"Cut a hole in the picture with my mask"
		destOrigin: bwForm offset 
		sourceOrigin: 0@0
		extent: self extent clipRect: self boundingBox)
		colorMap: (Bitmap with: 0 with: 16rFFFFFFFF))
		copyBits.
	self fillShape: bwForm fillColor: aColor.
	^ bwForm