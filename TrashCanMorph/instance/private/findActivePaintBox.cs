findActivePaintBox
	"If painting, return the active PaintBoxMorph. If not painting, or if the paint box cannot be found, return nil."

	| w m |
	w _ self world.
	w ifNil: [^ nil].
	(w findA: SketchEditorMorph) ifNil: [^ nil].  "not painting"
	(m _ w findA: PaintBoxMorph) ifNotNil: [^ m].
	^ nil
