star: newEvent
	"verts _ (0 to: 350 by: 36) collect: [:angle |
		(Point r: (oldR _ oldR = ext ifTrue: [ext*5//12] ifFalse: [ext]) degrees: angle + pt degrees)
			+ strokeOrigin].
	
	poly _ PolygonMorph new addHandles.
	poly color: currentColor; borderWidth: currentNib extent x; borderColor: Color black.
	poly privateOwner: self.
	poly bounds: (strokeOrigin extent: ext).
	poly setVertices: verts.
	poly drawOn: formCanvas."