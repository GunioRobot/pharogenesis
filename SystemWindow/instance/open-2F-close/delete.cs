delete
	| thisWorld sketchEditor aPaintBox |
	self mustNotClose ifTrue: [^ self].
	model okToChange ifFalse: [^ self].
	thisWorld _ self world.
	sketchEditor _ self extantSketchEditor.
	self isFlexed
		ifTrue: [owner delete]
		ifFalse: [super delete].
	model windowIsClosing; release.
	model _ nil.
	sketchEditor ifNotNil:
		[sketchEditor deleteSelfAndSubordinates.
		thisWorld notNil ifTrue:
			[(aPaintBox _ thisWorld paintBoxOrNil) ifNotNil: [aPaintBox delete]]].
		
	SystemWindow noteTopWindowIn: thisWorld.
