updateTrailsForm 
	"Update the turtle-trails form using the current positions of all pens.
	Only used in conjunction with Preferences batchPenTrails."

	"Details: The positions of all morphs with their pens down are recorded each time the draw method is called. If the list from the previous display cycle isn't empty, then trails are drawn from the old to the new positions of those morphs on the turtle-trails form. The turtle-trails form is created on demand when the first pen is put down and removed (to save space) when turtle trails are cleared."

	| morph oldPoint newPoint removals player tfm |

	self flag: #bob.		"transformations WRONG here"

	(lastTurtlePositions == nil or: [lastTurtlePositions size = 0]) ifTrue: [^ self].

	removals _ OrderedCollection new.
	lastTurtlePositions associationsDo: [:assoc |
		player _ assoc key.
		morph _ player costume.
		(player getPenDown and: [morph trailMorph == self])
			 ifTrue:
				[oldPoint _ assoc value.
				tfm _ morph owner transformFrom: self.
				newPoint _ tfm localPointToGlobal: morph referencePosition.
				newPoint = oldPoint ifFalse:
					[assoc value: newPoint.
					self drawPenTrailFor: morph from: oldPoint to: newPoint]]
			ifFalse: [removals add: player]].
	removals do: [:key | lastTurtlePositions removeKey: key ifAbsent: []]