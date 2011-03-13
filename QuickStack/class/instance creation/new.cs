new
	^ (super new: 16) initialize
	"Why 16?  Because in performing an abstract interpretation of every
	method in every Class <= Object, the largest stack that was found 
	to be necessary was 15"