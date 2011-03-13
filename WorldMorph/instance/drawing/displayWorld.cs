displayWorld
	"Update this world's display."

	| deferredUpdateMode updateNeeded worldDamageRects handsToDraw handDamageRects allDamage |
	submorphs do: [:m | m fullBounds].  "force re-layout if needed"
	updateNeeded _ damageRecorder updateIsNeeded.
	updateNeeded ifFalse: [
		hands do: [:h |
			(h hasChanged and: [h needsToBeDrawn])
				ifTrue: [updateNeeded _ true]]].
	updateNeeded ifFalse: [^ self].  "display is already up-to-date"

	deferredUpdateMode _ self doDeferredUpdating.
	deferredUpdateMode ifFalse: [self assuredCanvas].

	worldDamageRects _ self drawInvalidAreasOn: canvas.  "repair world's damage on canvas"
	handsToDraw _ self selectHandsToDrawForDamage: worldDamageRects.
	handDamageRects _ handsToDraw collect: [:h | h savePatchFrom: canvas].
	allDamage _ worldDamageRects, handDamageRects.

	handsToDraw reverseDo: [:h | h fullDrawOn: canvas].  "draw hands onto world canvas"
	false ifTrue: [  "*make this true to flash damaged areas for testing*"
		self flashRects: allDamage color: Color black].

	"quickly copy altered rects of canvas to Display:"
	deferredUpdateMode
		ifTrue: [allDamage do: [:r | Display forceToScreen: (r translateBy: viewBox origin)]]
		ifFalse: [canvas showAt: viewBox origin invalidRects: allDamage].
	handsToDraw do: [:h | h restoreSavedPatchOn: canvas].  "restore world canvas under hands"
	Display deferUpdates: false; forceDisplayUpdate.
