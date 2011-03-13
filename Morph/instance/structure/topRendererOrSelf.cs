topRendererOrSelf
	"Answer the topmost renderer for this morph, or this morph itself if it has no renderer. See the comment in Morph>isRenderer."

	| top topsOwner |
	owner ifNil: [^ self].
	top _ self.
	topsOwner _ top owner.
	[(topsOwner ~~ nil) and: [topsOwner isRenderer]] whileTrue: [
		top _ topsOwner.
		topsOwner _ top owner].
	^ top
