collapse
	
	| priorPosition w collapsedVersion a |

	(w := self world) ifNil: [^self].
	collapsedVersion := (self imageForm scaledToSize: 50@50) asMorph.
	collapsedVersion setProperty: #uncollapsedMorph toValue: self.
	collapsedVersion on: #mouseUp send: #uncollapseSketch to: collapsedVersion.
	collapsedVersion setBalloonText: 'A collapsed version of ',self name.
			
	self delete.
	w addMorphFront: (
		a := AlignmentMorph newRow
			hResizing: #shrinkWrap;
			vResizing: #shrinkWrap;
			borderWidth: 4;
			borderColor: Color white;
			addMorph: collapsedVersion
	).
	collapsedVersion setProperty: #collapsedMorphCarrier toValue: a.

	(priorPosition := self valueOfProperty: #collapsedPosition ifAbsent: [nil])
	ifNotNil:
		[a position: priorPosition].
