tossOutArg: extras

	"Remove the tiles for the last N keywords and arguments.  Place the tiles beside the current window.  I am a SyntaxMorph for a MessageNode."

	| cnt ctr |
	cnt _ 0.
	 submorphs copy reverseDo: [:sub |
		ctr _ sub fullBoundsInWorld center.
		sub delete.
		(sub isSyntaxMorph and: [sub parseNode notNil]) ifTrue: [
			sub isNoun ifTrue: [
				self pasteUpMorph addMorphFront: sub.
				sub position: self enclosingPane fullBoundsInWorld right - 20 @ ctr y].
			(cnt _ cnt + 1) >= extras ifTrue: [^ self]]].