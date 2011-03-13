mouseEnter: evt
	"Set the cursor.  Reread colors if embedded editable polygon needs it."

	| poly cColor |
	super mouseEnter: evt.
	self flag: #arNote. "What is that code below doing???"
	(self get: #action for: evt) == #scaleOrRotate ifTrue: [
		self set: #action for: evt to: (self get: #priorAction for: evt).
	].
	evt hand showTemporaryCursor: (self getCursorFor: evt).
	palette getSpecial == #polygon: ifFalse: [^self].
	(poly _ self valueOfProperty: #polygon) ifNil: [^ self].
	cColor _ self getColorFor: evt.
	poly color: cColor; borderWidth: 1.
	poly changed.