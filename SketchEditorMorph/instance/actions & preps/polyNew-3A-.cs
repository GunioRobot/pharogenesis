polyNew: evt
	"Create a new polygon.  Add it to the sketch, and let the user drag
its vertices around!  Freeze it into the painting when the user chooses
another tool."

	| poly cColor |
	self polyEditing ifTrue:[
		self polyFreeze.
		(self hasProperty: #polyCursor)
			ifTrue:[palette plainCursor: (self valueOfProperty: #polyCursor) event: evt.
					self removeProperty: #polyCursor].
		^self].
	cColor _ self getColorFor: evt.
	self polyFreeze.		"any old one we were working on"
	poly _ PolygonMorph new "addHandles".
	poly referencePosition: poly bounds origin.
	poly align: poly bounds center with: evt cursorPoint.
 	cColor == Color transparent
	ifFalse:[
	poly color: cColor; borderWidth: 0;
	borderColor: Color transparent]
	ifTrue:[
	poly color: cColor; borderWidth: 1;     "still some problems with brushsize !!"
	borderColor: Color black].
	self addMorph: poly.
	poly changed.
	self setProperty: #polygon toValue: poly.