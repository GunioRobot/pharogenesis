addImageToPenTrails: aForm 
	"The turtleTrailsForm is created on demand when the first pen is put  
	down and removed (to save space) when turtle trails are cleared."
	self createOrResizeTrailsForm.
	aForm
		displayOn: turtleTrailsForm
		at: self topLeft negated
		rule: Form paint.
	self
		invalidRect: (aForm offset extent: aForm extent)