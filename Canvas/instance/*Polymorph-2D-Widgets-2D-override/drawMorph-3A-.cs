drawMorph: aMorph
	"Changed to improve performance. Have seen a 30% improvement."	

	(aMorph fullBounds intersects: self clipRect)
		ifFalse: [^self].
	self draw: aMorph