initialize

	super initialize.
	self setColor: (Color r: 0.8 g: 0.8 b: 0.8) borderWidth: 2 borderColor: #raised.
	inset _ 3.
	orientation _ #vertical.
	hResizing _ #shrinkWrap.
	vResizing _ #shrinkWrap.
	defaultTarget _ nil.
	lastSelection _ nil.
	stayUp _ false.
	originalEvent _ nil.
	popUpOwner _ nil.
