sproutNewScriptor
	"The receiver, operating as a naked phrase tile, wishes to get iself placed in a nascent script"

	| newScriptor |

	self actualObject assureUniClass.
	newScriptor _ self actualObject newScriptorAround:
		((self ownerThatIsA: Viewer orA: ScriptEditorMorph)
			ifNotNil:
				[self fullCopy]
			ifNil:
				[self]).
	self currentHand attachMorph: newScriptor