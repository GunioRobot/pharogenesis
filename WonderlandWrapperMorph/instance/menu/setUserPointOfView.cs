setUserPointOfView
	| morph |
	morph _ self getCameraMorph.
	morph == nil ifTrue:[^self].
	myActor setUserPointOfView: (morph getCamera getPointOfView: myActor).