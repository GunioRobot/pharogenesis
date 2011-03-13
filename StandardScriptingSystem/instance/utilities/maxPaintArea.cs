maxPaintArea
	"Answer the largest paintable area for new 'make new drawing'"
	"ScriptingSystem maxPaintArea"

	| anExtent |
	anExtent _ self reasonablePaintingExtent.
	^ anExtent x * anExtent y