repaintMorphicDisplay

	"this merely says everything needs to be redrawn, but the actual redraw will happen later"

	(self getOuterMorphicWorld ifNil: [^self]) fullRepaintNeeded.	
