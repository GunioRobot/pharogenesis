acceptInCategory: categoryString
	"Turn my current state into the text of a method.  Compile it in my class."
	| cls sc sel |
	self isMethodNode ifFalse: [
		self rootTile == self ifTrue: [^ self].  "not in a script"
		^ self rootTile accept  "always accept at the root"].
	(cls _ self parsedInClass) ifNil: [^ self].
	sel _ cls compile: self decompile classified: categoryString.
	(sc _ self firstOwnerSuchThat: [:mm | mm class == ScriptEditorMorph]) 
		ifNotNil: [sc hibernate; unhibernate].	"rebuild the tiles"
	^ sel