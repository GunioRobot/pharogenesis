animationExample
	"PolygonMorphDashed animationExample"
	| m numOfAnimationSteps start stop stepVec s delay delayAtAll point animation |
	m _ self
				vertices: {Display boundingBox origin. Display boundingBox corner}
				color: Color transparent
				firstBorderWidth: 2
				secondBorderWidth: 2
				firstBorderColor: Color black
				secondBorderColor: Color white
				firstBorderStepWidth: 10
				secondBorderStepWidth: 10.
	m lock.
	m openInWorld.
	World refreshWorld.
	(Delay forSeconds: 1) wait.
	numOfAnimationSteps _ 25.
	delayAtAll _ 1.
	start _ m vertices at: 1.
	stop _ m vertices at: 2.
	start = stop ifTrue: [^ self].
	stepVec _ stop - start / (numOfAnimationSteps + 1).
	s _ Array new: numOfAnimationSteps.
	1 to: numOfAnimationSteps do: 
		[:step | 
		point _ start + (step * stepVec).
		"avoid problems"
		s at: step put: (point = stop
				ifTrue: 
					[
					stop - (1 @ 1)]
				ifFalse: [point])].
	delay _ Delay forSeconds: delayAtAll / numOfAnimationSteps.
	animation _ 
			[1 to: s size do: 
				[:j | 
				"Move to the next point"
				m vertices at: 1 put: (s at: j).
				"update"
				m computeBounds.
				"not necessary here since forked"
				"	World refreshWorld."
				"for fast machines"
				delay wait].
			m delete].
	animation fork