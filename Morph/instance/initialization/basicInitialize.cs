basicInitialize
	"Do basic generic initialization of the instance variables:  
	Set up the receiver, created by a #basicNew and now ready to  
	be initialized, by placing initial values in the instance variables  
	as appropriate"
	owner := nil.
	submorphs := EmptyArray.
	bounds := self defaultBounds.
	color := self defaultColor