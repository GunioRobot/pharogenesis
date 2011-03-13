collapse
	
	| priorPosition w collapsedVersion a |

	(w _ self world) ifNil: [^self].
	collapsedVersion _ (self imageForm scaledToSize: 50@50) asMorph.
	collapsedVersion setProperty: #uncollapsedMorph toValue: self.
	collapsedVersion on: #mouseUp send: #uncollapseSketch to: collapsedVersion.
	collapsedVersion setBalloonText: 'A collapsed version of ',self name.
			
	self delete.
	w addMorphFront: (
		a _ AlignmentMorph newRow
			hResizing: #shrinkWrap;
			vResizing: #shrinkWrap;
			borderWidth: 4;
			borderColor: Color white;
			addMorph: collapsedVersion
	).
	collapsedVersion setProperty: #collapsedMorphCarrier toValue: a.

	(priorPosition _ self valueOfProperty: #collapsedPosition ifAbsent: [nil])
	ifNotNil:
		[a position: priorPosition].
