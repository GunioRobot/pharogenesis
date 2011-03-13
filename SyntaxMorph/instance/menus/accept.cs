accept
	"Turn my current state into the text of a method.  Compile it in my class."
	| cls sc |
	self isMethodNode ifFalse: [
		self rootTile == self ifTrue: [^ self].  "not in a script"
		^ self rootTile accept  "always accept at the root"].
	(cls _ self parsedInClass) ifNil: [^ self].
	cls compile: self decompile notifying: nil.
	(sc _ self firstOwnerSuchThat: [:mm | mm class == ScriptEditorMorph]) 
		ifNotNil: [sc hibernate; unhibernate].	"rebuild the tiles"
