test1   "Display restoreAfter: [WarpBlt test1]"
	"Demonstrates variable to scale and rotate"
	| warp pts r1 p0 p ext |
	Utilities informUser: 'Choose a rectangle with interesting stuff'
		during: [r1 _ Rectangle originFromUser: 50@50.
				Sensor waitNoButton].
	Utilities informUser: 'Now click and move the mouse around'
		during: [p0 _ Sensor waitClickButton.
				(Form dotOfSize: 8) displayAt: p0].
	warp _ (WarpBlt toForm: Display)
		clipRect: (0@0 extent: r1 extent*5);
		sourceForm: Display;
		combinationRule: Form over.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint.
		pts _ {r1 topLeft. r1 bottomLeft. r1 bottomRight. r1 topRight}
			collect: [:pt | pt rotateBy: (p-p0) theta about: r1 center].
		ext _ (r1 extent*((p-p0) r / 20.0 max: 0.1)) asIntegerPoint.
		warp copyQuad: pts toRect: (r1 extent*5-ext//2 extent: ext)]