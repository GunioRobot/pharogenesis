searchForNewTopAtX: xValue y: yValue
	"A top face ended with no known right face.
	We have to search the fill list for the face with the smallest z value.
	Note: In theory, this should only happen on *right* boundaries of meshes
	and thus not affect performance too much. Having the fillList sorted by
	its minimal z value should help, too."
	| face topFace topZ faceZ floatX floatY |
	self isEmpty ifTrue:[^self]. "No top"
	floatX _ xValue / 4096.0.
	floatY _ yValue.
	face _ self first.
	topFace _ face.
	topZ _ face zValueAtX: floatX y: floatY.
	[face _ face nextFace.
	face == nil] whileFalse:[
		face minZ > topZ ifTrue:[
			"Done. Everything else is behind."
			self remove: topFace.
			self addFront: topFace.
			^self].
		faceZ _ face zValueAtX: floatX y: floatY.
		faceZ < topZ ifTrue:[
			topZ _ faceZ.
			topFace _ face]].
	self remove: topFace.
	self addFront: topFace.