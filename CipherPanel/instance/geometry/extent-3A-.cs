extent: newExtent 
	"Lay out with word wrap, alternating bewteen decoded and encoded lines."
	"Currently not tolerant of narrow (less than a word) margins"

	| w h relLoc topLeft thisWord i m corner row firstWord |
	self removeAllMorphs.
	w _ originalMorphs first width - 1.  h _ originalMorphs first height * 2 + 10.
	topLeft _ self position + self borderWidth + (0@10).
	thisWord _ OrderedCollection new.
	i _ 1.  firstWord _ true.  relLoc _ 0@0.  corner _ topLeft.
	[i <= originalMorphs size] whileTrue:
		[m _ originalMorphs at: i.
		thisWord addLast: ((decodingMorphs at: i) position: topLeft + relLoc).
		thisWord addLast: (m position: topLeft + relLoc + (0@m height)).
		(m letter = Character space or: [i = originalMorphs size])
			ifTrue: [self addAllMorphs: thisWord.
					corner _ corner max: thisWord last bounds bottomRight.
					thisWord reset.  firstWord _ false].
		relLoc _ relLoc + (w@0).
		(relLoc x + w) > newExtent x
			ifTrue: [firstWord
						ifTrue: ["No spaces -- force a line break"
								thisWord removeLast; removeLast.
								self addAllMorphs: thisWord.
								corner _ corner max: thisWord last bounds bottomRight]
						ifFalse: [i _ i - (thisWord size//2) + 1].
					thisWord reset.  firstWord _ true.
					relLoc _ 0@(relLoc y + h)]
			ifFalse: [i _ i + 1]].
	row _ self buttonRow. row fullBounds.
	self addMorph: row.
	super extent: (corner - topLeft) + (self borderWidth * 2) + (0@row height+10).
	row align: row bounds bottomCenter with: self bounds bottomCenter - (0@2).