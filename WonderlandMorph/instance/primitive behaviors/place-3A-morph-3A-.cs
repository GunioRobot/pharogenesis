place: aLocation morph: aMorph
	"Place this WonderlandMorph in the specified location relative to the specified morph over 1 second using the gently animation style."

	^ self place: aLocation morph: aMorph duration: 1.0 style: gently.
