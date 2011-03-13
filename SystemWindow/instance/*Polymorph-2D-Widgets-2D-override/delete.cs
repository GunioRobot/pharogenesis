delete
	"Should activate window before asking model if okToChange
	since likely that a confirmation dialog will be requested.
	Don't if not owned by the world though."
	
	| thisWorld sketchEditor aPaintBox animateClose|
	self mustNotClose ifTrue: [^ self].
	(self owner notNil and: [self owner isWorldMorph])
		ifTrue: [self activate].
	model okToChange ifFalse: [^ self].
	animateClose := (self visible and: [self world notNil and: [
		Preferences windowAnimation and: [
		Preferences noWindowAnimationForClosing not]]]).
	self removePaneSplitters. "in case we add some panes and reopen!"
	thisWorld := self world.
	sketchEditor := self extantSketchEditor.
	self isFlexed
		ifTrue: [owner delete]
		ifFalse: [super delete].
	model windowIsClosing; release.
	model := nil.
	animateClose ifTrue: [self animateClose].
	sketchEditor ifNotNil:
		[sketchEditor deleteSelfAndSubordinates.
		thisWorld notNil ifTrue:
			[(aPaintBox := thisWorld paintBoxOrNil) ifNotNil: [aPaintBox delete]]].
		
	SystemWindow noteTopWindowIn: thisWorld.
