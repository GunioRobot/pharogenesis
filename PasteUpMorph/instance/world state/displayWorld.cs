displayWorld
	"Update this world's display."

	| deferredUpdateMode updateNeeded worldDamageRects handsToDraw handDamageRects allDamage |
	submorphs do: [:m | m fullBounds].  "force re-layout if needed"
	updateNeeded _ self damageRecorder updateIsNeeded.
	updateNeeded ifFalse: [
		self handsDo: [:h |
			(h hasChanged and: [h needsToBeDrawn])
				ifTrue: [updateNeeded _ true]]].
	updateNeeded ifFalse: [^ self].  "display is already up-to-date"

	deferredUpdateMode _ self doDeferredUpdating.
	deferredUpdateMode ifFalse: [self assuredCanvas].

	worldDamageRects _ self drawInvalidAreasOn: self canvas.  "repair world's damage on canvas"
	handsToDraw _ self selectHandsToDrawForDamage: worldDamageRects.
	handDamageRects _ handsToDraw collect: [:h | h savePatchFrom: self canvas].
	allDamage _ worldDamageRects, handDamageRects.

	handsToDraw reverseDo: [:h | h fullDrawOn: self canvas].  "draw hands onto world canvas"
	false ifTrue: [  "*make this true to flash damaged areas for testing*"
		self flashRects: allDamage color: Color black].

	self canvas finish.
	"quickly copy altered rects of canvas to Display:"
	deferredUpdateMode
		ifTrue: [allDamage do: [:r | Display forceToScreen: (r "translateBy: self viewBox origin")]]
		ifFalse: [self canvas showAt: self viewBox origin invalidRects: allDamage].
	handsToDraw do: [:h | h restoreSavedPatchOn: self canvas].  "restore world canvas under hands"
	Display deferUpdates: false; forceDisplayUpdate.
