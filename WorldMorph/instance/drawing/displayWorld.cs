displayWorld
	"Update this world's display."

	| rectList |
	submorphs do: [:m | m fullBounds].  "force re-layout if needed"
	damageRecorder updateIsNeeded ifFalse: [^ self].  "display is already up-to-date"

	(canvas == nil or:
	 [(canvas extent ~= viewBox extent) or:
	 [canvas form depth ~= Display depth]]) ifTrue: [
		"allocate a new offscreen canvas the size of the window"
		self canvas: (FormCanvas extent: viewBox extent)].

	false ifTrue: [  "*make this true to flash damaged areas for testing*"
		damageRecorder blackenDamageOn: canvas.
		canvas showAt: viewBox origin].

	rectList _ self drawInvalidAreasOn: canvas.  "redraw on offscreen canvas"
	canvas showAt: viewBox origin invalidRects: rectList.  "copy redrawn rects to Display"
	Smalltalk forceDisplayUpdate.