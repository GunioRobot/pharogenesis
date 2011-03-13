star: evt 
	"Draw an star from the center."
	| poly ext ww rect oldExt oldRect oldR verts pt cColor sOrigin priorEvt |
	sOrigin _ self get: #strokeOrigin for: evt.
	cColor _ self getColorFor: evt.
	ww _ (self getNibFor: evt) width.
	ext _ (pt _ sOrigin - evt cursorPoint) r + ww * 2.
	rect _ Rectangle center: sOrigin extent: ext.
	(priorEvt _ self get: #lastEvent for: evt)
		ifNotNil: [oldExt _ (sOrigin - priorEvt cursorPoint) r + ww * 2.
			"Last draw sticks out, must erase the area"
			oldRect _ Rectangle center: sOrigin extent: oldExt.
			self restoreRect: oldRect].
	ext _ pt r.
	oldR _ ext.
	verts _ (0 to: 350 by: 36)
				collect: [:angle | (Point r: (oldR _ oldR = ext
									ifTrue: [ext * 5 // 12]
									ifFalse: [ext]) degrees: angle + pt degrees)
						+ sOrigin].
	poly _ PolygonMorph new addHandles.
	cColor == Color transparent
		ifTrue: [poly color: cColor;
				 borderWidth: 1;
				 borderColor: Color black]
		ifFalse: [poly color: cColor;
				 borderWidth: 0;
				 borderColor: Color transparent].
	"can't handle thick brushes"
	self invalidRect: rect.
	"self addMorph: poly."
	poly privateOwner: self.
	poly
		bounds: (sOrigin extent: ext).
	poly setVertices: verts.
	poly drawOn: formCanvas.
	"poly delete."
	self invalidRect: rect