addImageToPenTrailsFor: aMorph

	"The turtleTrailsForm is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."
	| image |

	self createOrResizeTrailsForm.
	"origin _ self topLeft."
	image _ aMorph imageForm offset: 0@0.
	image
		displayOn: turtleTrailsForm 
		at: aMorph topLeft - self topLeft
		rule: Form paint.
	self invalidRect: (image boundingBox translateBy: aMorph topLeft).
