createArrowOfDirection: aSymbolDirection size: finalSizeInteger color: aColor 
	"PRIVATE - create an arrow with aSymbolDirectionDirection,  
	finalSizeInteger and aColor  
	 
	aSymbolDirectionDirection = #top, #bottom. #left or #right  
	 
	Try with:  
	(ScrollBar createArrowOfDirection: #top size: 32 color: Color  
	lightGreen) asMorph openInHand.  
	"
	| resizeFactor outerBox arrow resizedForm |
	resizeFactor := 4.
	outerBox := RectangleMorph new.
	outerBox extent: finalSizeInteger asPoint * resizeFactor;
		 borderWidth: 0;
		 color: aColor.
	""
	arrow := self createArrowOfDirection: aSymbolDirection in: outerBox bounds.
	self updateScrollBarButtonAspect: arrow color: aColor muchDarker.
	outerBox addMorphCentered: arrow.
	""
	resizedForm := outerBox imageForm
				magnify: outerBox imageForm boundingBox
				by: 1 / resizeFactor
				smoothing: 4.
	""
	^ (resizedForm replaceColor: aColor withColor: Color transparent)
		trimBordersOfColor: Color transparent