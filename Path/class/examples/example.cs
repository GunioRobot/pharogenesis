example
	"Creates a Path from mousePoints and displays it several ways on the display screen. Messes up the display. For learning about class Path, just select the code below and execute it to create a path and see it redisplayed in another place on the screen. Each path displays using a different form. A path is indicated by pressing the red mouse button in a sequence; press any other mouse button to terminate. "

	| aPath aForm pl fl flag |
	aForm _ Form extent: 2 @ 40.		"creates a form one inch long"
	aForm fillBlack.							"turns it black"
	aPath _ Path new.
	aPath form: aForm.						"use the long black form for displaying"
	flag _ true.
	[flag]
		whileTrue: 
			[Sensor waitButton.
			Sensor redButtonPressed
				ifTrue: 
					[aPath add: Sensor waitButton.
					Sensor waitNoButton.
					aForm displayOn: Display at: aPath last]
				ifFalse: [flag _ false]].
	Display fillWhite.
	aPath displayOn: Display.			"the original path"
	pl _ aPath translateBy: 0 @ 100.
	fl _ Form extent: 40 @ 40.
	fl fillGray.
	pl form: fl.
	pl displayOn: Display.				"the translated path"
	Sensor waitNoButton

	"Path example"