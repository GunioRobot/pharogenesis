polyNew: evt
	"Create a new polygon.  Add it to the sketch, and let the user drag
its vertices around!  Freeze it into the painting when the user chooses
another tool."

	| poly |
	self polyFreeze.		"any old one we were working on"
	poly _ PolygonMorph new addHandles.
 	currentColor == Color transparent
	ifFalse:[
	poly color: currentColor; borderWidth: 0;
	borderColor: Color transparent]
	ifTrue:[
	poly color: currentColor; borderWidth: 1;     "still some problems with brushsize !!"
	borderColor: Color black].
	poly position: evt cursorPoint.
	self addMorph: poly.
	poly changed.
	self setProperty: #polygon toValue: poly.