fromDisplay: aRectangle 
	"Copy from the Display, using an appropriate color map"

	(width = aRectangle width and: [height = aRectangle height])
		ifFalse: [self extent: aRectangle extent].
	(BitBlt toForm: self)
		destOrigin: 0@0;
		sourceForm: Display;
		sourceRect: aRectangle;
		combinationRule: Form over;
		colorMap: (self colorMapFrom: Display);
		copyBits