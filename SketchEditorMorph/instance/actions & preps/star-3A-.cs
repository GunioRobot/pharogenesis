star: evt
	"Draw an star from the center. "

	| poly ext ww rect oldExt oldRect oldR verts pt |
	ww _ palette getNib width.
	ext _ (pt _ strokeOrigin - evt cursorPoint) r + ww * 2.
	rect _ Rectangle center: strokeOrigin extent: ext.
	ww _ palette getNib width.
	lastEvent ifNotNil: [
		oldExt _ (strokeOrigin - lastEvent cursorPoint) r + ww * 2.
		"Last draw sticks out, must erase the area"
		oldRect _ Rectangle center: strokeOrigin extent: oldExt.
		self restoreRect: oldRect].
	ext _ pt r.
	oldR _ ext.
	verts _ (0 to: 350 by: 36) collect: [:angle |
		(Point r: (oldR _ oldR = ext ifTrue: [ext*5//12] ifFalse: [ext]) degrees: angle + pt degrees)
			+ strokeOrigin].
	
	poly _ PolygonMorph new addHandles.
	currentColor == Color transparent
	ifFalse:[
	poly color: currentColor; borderWidth: 0; borderColor: Color transparent.]
	ifTrue:[
	poly color: currentColor; borderWidth: 1; borderColor: Color black ]. " can't handle thick brushes"
	self invalidRect: rect.

	
	"self addMorph: poly."
	poly privateOwner: self.
	poly bounds: (strokeOrigin extent: ext).
	poly setVertices: verts.
	poly drawOn: formCanvas.
	"poly delete."
	self invalidRect: rect.
