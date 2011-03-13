embedInto: evt
	"Embed the receiver into some other morph"
	|  menu target |
	menu _ CustomMenu new.
	self potentialEmbeddingTargets  do: [:m | 
		menu add: (m knownName ifNil:[m class name asString]) action: m].
	target _ menu startUpWithCaption: ('Place ', self externalName, ' in...').
	target ifNil:[^self].
	target addMorphFront: self fromWorldPosition: self positionInWorld.