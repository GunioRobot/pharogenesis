replaceSubmorph: oldMorph by: newMorph
	| t b |
	t _ transform.
	b _ bounds.
	super replaceSubmorph: oldMorph by: newMorph.
	transform _ t.
	bounds _ b.
	self layoutChanged