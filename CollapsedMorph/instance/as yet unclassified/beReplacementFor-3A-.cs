beReplacementFor: aMorph

	| itsWorld priorPosition |
	(itsWorld _ aMorph world) ifNil: [^self].
	uncollapsedMorph _ aMorph.
			
	self setLabel: aMorph externalName.
	aMorph delete.
	itsWorld addMorphFront: self.
	self collapseOrExpand.
	(priorPosition _ aMorph valueOfProperty: #collapsedPosition ifAbsent: [nil])
	ifNotNil:
		[self position: priorPosition].
