pageControlsMorphFrom: controlSpecs
	"Answer a controls morph derived from the spec supplied"

	| controls |
	controls _ super pageControlsMorphFrom: controlSpecs.
	controls eventHandler: nil.  "not grabbable"
	^ controls