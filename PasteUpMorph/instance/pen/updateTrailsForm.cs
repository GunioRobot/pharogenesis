updateTrailsForm
	"Update the turtle-trails form using the current positions of all pens.
	Only used in conjunction with Preferences batchPenTrails."

	"Details: The positions of all morphs with their pens down are recorded each time the draw method is called. If the list from the previous display cycle isn't empty, then trails are drawn from the old to the new positions of those morphs on the turtle-trails form. The turtle-trails form is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."

	| morph oldPoint newPoint removals player tfm |
	self flag: #bob.	"transformations WRONG here"
	(lastTurtlePositions isNil or: [lastTurtlePositions isEmpty]) 
		ifTrue: [^self].
	removals := OrderedCollection new.
	lastTurtlePositions associationsDo: 
			[:assoc | 
			player := assoc key.
			morph := player costume.
			(player getPenDown and: [morph trailMorph == self]) 
				ifTrue: 
					[oldPoint := assoc value.
					tfm := morph owner transformFrom: self.
					newPoint := tfm localPointToGlobal: morph referencePosition.
					newPoint = oldPoint 
						ifFalse: 
							[assoc value: newPoint.
							self 
								drawPenTrailFor: morph
								from: oldPoint
								to: newPoint]]
				ifFalse: [removals add: player]].
	removals do: [:key | lastTurtlePositions removeKey: key ifAbsent: []]