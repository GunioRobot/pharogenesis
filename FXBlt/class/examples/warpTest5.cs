warpTest5   "Display restoreAfter: [FXBlt warpTest5]"
	"Demonstrates variable scale and rotate"
	| warp pts r1 p0 p |
	Utilities informUser: 'Choose a rectangle with interesting stuff'
		during: [r1 _ Rectangle fromUser.
				Sensor waitNoButton].
	Utilities informUser: 'Now click down and up
and move the mouse around the dot'
		during: [p0 _ Sensor waitClickButton.
				(Form dotOfSize: 8) displayAt: p0].
	warp _ (self toForm: Display)
		cellSize: 1;
		sourceForm: Display;
		cellSize: 2;  "installs a colormap"
		combinationRule: Form over.
	[Sensor anyButtonPressed] whileFalse:
		[p _ Sensor cursorPoint.
		pts _ {r1 topLeft. r1 bottomLeft. r1 bottomRight. r1 topRight}
			collect: [:pt | pt rotateBy: (p-p0) theta about: r1 center].
		warp copyQuad: pts toRect: (r1 translateBy: r1 width@0)]