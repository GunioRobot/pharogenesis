backgroundSketch: aSketchMorphOrNil
	"Set the receiver's background graphic as indicated.  If nil is supplied, remove any existing background graphic.  In any case, delete any preexisting background graphic."

	backgroundMorph ifNotNil: [backgroundMorph delete].  "replacing old background"

	aSketchMorphOrNil ifNil: [backgroundMorph _ nil.  ^ self].

	backgroundMorph _ StickySketchMorph new form: aSketchMorphOrNil form.
	backgroundMorph position: aSketchMorphOrNil position.
	self addMorphBack: backgroundMorph.
	aSketchMorphOrNil delete.
	backgroundMorph lock.
	backgroundMorph setProperty: #shared toValue: true.
	^ backgroundMorph
