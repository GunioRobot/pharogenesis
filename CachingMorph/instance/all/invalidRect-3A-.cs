invalidRect: damageRect
	"Record the given rectangle in the damage list."

	damageRecorder recordInvalidRect: (damageRect translateBy: self fullBounds origin negated).
	super invalidRect: damageRect.
