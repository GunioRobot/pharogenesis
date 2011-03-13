addGraphicalHandleFrom: formKey at: aPoint
	"Add the supplied form as a graphical handle centered at the given point.  Return the handle."
	| handle aForm |
	aForm _ (ScriptingSystem formAtKey: formKey) ifNil: [ScriptingSystem formAtKey: #SolidMenu].
	handle _ ImageMorph new image: aForm; bounds: (Rectangle center: aPoint extent: aForm extent).
	handle wantsYellowButtonMenu: false.
	self addMorph: handle.
	handle on: #mouseUp send: #endInteraction to: self.
	^ handle
