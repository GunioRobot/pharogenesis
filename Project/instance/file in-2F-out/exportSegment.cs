exportSegment
	"Store my project out on the disk as an *exported* ImageSegment.  Put all outPointers in a form that can be resolved in the target image.  Name it <project name>.extSeg.
	Player classes are included automatically."

	^ self exportSegmentWithCatagories: #() classes: #()
