nTemps: n literals: lits class: cl 
	"Decompile."

	supered := false.
	class := cl.
	nTemps := n.
	(literalStream := lits readStream) position: lits size.
	sourceRanges := Dictionary new: 32.
	globalSourceRanges := OrderedCollection new: 32.
