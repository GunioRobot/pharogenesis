releaseCachedState
	| svg svgon oo |
	super releaseCachedState.
	cacheCanvas _ nil.
	svg _ grid.
	svgon _ gridOn.
	oo _ owner.
	self removeAllMorphs.
	self initialize.	"nuke everything"
	self privateOwner: oo.
	grid _ svg.
	gridOn _ svgon.
	mouseDownMorph _ nil.
	argument _ nil.
	formerOwner _ nil.