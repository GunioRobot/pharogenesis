temps: tempVars literals: lits class: cl 
	"Decompile."

	supered _ false.
	class _ cl.
	nTemps _ tempVars size.
	tempVars do: [:node | scopeTable at: node name put: node].
	literalStream _ ReadStream on: lits.
	literalStream position: lits size.
	sourceRanges _ Dictionary new: 32.
	globalSourceRanges _ OrderedCollection new: 32.
