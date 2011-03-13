example
	"Designate points on the Path by clicking the red button. Terminate by
	pressing any other button. A curve will be displayed, through the
	selected points, using a long black form."

	| splineCurve aForm flag|
	aForm _ Form extent: 1@40.
	aForm  fillBlack.
	splineCurve _ Spline new.
	splineCurve form: aForm.
	flag _ true.
	[flag] whileTrue:
		[Sensor waitButton.
		 Sensor redButtonPressed
			ifTrue: 
				[splineCurve add: Sensor waitButton. 
				 Sensor waitNoButton.
				 aForm displayOn: Display at: splineCurve last]
			ifFalse: [flag_false]].
	splineCurve computeCurve.
	splineCurve isEmpty 
		ifFalse: [splineCurve displayOn: Display.
				Sensor waitNoButton].
 
	"Spline example"