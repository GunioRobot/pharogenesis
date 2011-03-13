fitContentsUpTo: maxFitSize
	"Implements the autoFit feature:  If the #maxAutoFitSize property is set, then change my size to track any changes in the extent of my contents up to the max extent.  Above that extent, use scrollbars.  Typically one uses the #hideUnneededScrollbars property as well."

	"Adjust my size to fit my contents reasonably snugly"

	self extent: (scroller contentBounds extent
				+ (yScrollBar width@xScrollBar height)
				+ (borderWidth*2) min: maxFitSize)
				 