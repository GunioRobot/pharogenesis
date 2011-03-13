acceptSilently
	"Turn my current state into the text of a method.  Compile it in my class.  Don't rebuild the tiles."
	| cls |

	self isMethodNode ifFalse: [
		self rootTile == self ifTrue: [^ self].  "not in a script"
		^ self rootTile acceptSilently  "always accept at the root"].
	(self ownerThatIsA: ScriptEditorMorph) ifNil: [^ self].
	(cls _ self parsedInClass) ifNil: [^ self].
	cls compile: self decompile notifying: nil.

