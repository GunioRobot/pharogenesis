drawOn: aCanvas 
	"Display the receiver, a spline curve, approximated by straight line 
	segments. Fill with the MPEG movie"

	| cm f filled quadRect |

	cm := Bitmap new: 2.
	cm at: 1 put: 0.
	cm at: 2 put: 32767.
	f := Form extent: self extent depth: 16.
	filled := self filledForm.
	(BitBlt toForm: f) sourceForm: filled;
		 sourceRect: filled boundingBox;
		
		destRect: (0 @ 0 extent: filled extent);
		 colorMap: cm;
		 combinationRule: Form over;
		 copyBits.
	quadNumber = 1
		ifTrue: [quadRect := Rectangle origin: form boundingBox topLeft corner: form boundingBox center].
	quadNumber = 2
		ifTrue: [quadRect := Rectangle origin: form boundingBox topCenter corner: form boundingBox rightCenter].
	quadNumber = 3
		ifTrue: [quadRect := Rectangle origin: form boundingBox leftCenter corner: form boundingBox bottomCenter].
	quadNumber = 4
		ifTrue: [quadRect := Rectangle origin: form boundingBox center corner: form boundingBox bottomRight].
	(BitBlt toForm: f) sourceForm: form;
		 sourceRect: quadRect;
		
		destRect: (0 @ 0 extent: f extent);
		 combinationRule: Form and;
		 copyBits.
	aCanvas image: f at: self position.
	self drawBorderOn: aCanvas.
	self drawArrowsOn: aCanvas