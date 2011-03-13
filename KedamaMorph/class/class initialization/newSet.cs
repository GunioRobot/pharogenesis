newSet

	| k p t s w |
	k _ self new.
	p _ k assuredPlayer getPatch costume renderedMorph.
	t _ k assuredPlayer newTurtleForSet.

	s _ SelectionMorph new.

	w _ PasteUpMorph new.
	w extent: 400@400.
	p position: 275@50.
	t position: 300@175.
	k position: 25@25.
	w addMorph: k.
	w addMorph: t.
	w addMorph: p.
	w addMorph: s.
	s bounds: w bounds.
	s selectSubmorphsOf: w.
	^ s.
