createBoxOfSize: finalSizeInteger color: aColor 
	"PRIVATE - create a box with finalSizeInteger and aColor  
	 
	Try with:  
	(ScrollBar createBoxOfSize: 32 color: Color lightGreen) asMorph  
	openInHand.  
	"
	| resizeFactor outerBox innerBox resizedForm |
	resizeFactor := 4.
	outerBox := RectangleMorph new.
	outerBox extent: finalSizeInteger asPoint * resizeFactor;
		 borderWidth: 0;
		 color: aColor.
	""
	innerBox := self createBoxIn: outerBox bounds.
	self updateScrollBarButtonAspect: innerBox color: aColor muchDarker.
	outerBox addMorphCentered: innerBox.
	""
	resizedForm := outerBox imageForm
				magnify: outerBox imageForm boundingBox
				by: 1 / resizeFactor
				smoothing: 4.
	""
	^ (resizedForm replaceColor: aColor withColor: Color transparent)
		trimBordersOfColor: Color transparent