setTarget: aMorph
	"Private! Set the target without adding handles."

	target _ aMorph topRendererOrSelf.
	innerTarget _ target renderedMorph.
