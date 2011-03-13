primitive
	"Answer the primitive index associated with the receiver. Zero indicates 
	that there is either no primitive or just a quick primitive."
	
	^ self header bitAnd: 16r1FF