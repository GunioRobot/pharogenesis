test2   "Display restoreAfter: [WarpBlt test2]"
	"Magnifying demonstration of WarpBlt's ability to scale and deform"
	| s nineRects rm nineQuads warp cp cursorQuads |
	s _ 50.
	nineRects _ (1 to: 9) collect:
		[:i | (i-1\\3*s) @ (i-1//3*s) extent: s@s].
	rm _ (nineRects at: 5) insetBy: s//3.
	nineQuads _ nineRects collect: [:r | r corners].
	nineQuads do:
		[:q | (nineRects at: 5) corners doWithIndex:
			[:c :i | 1 to: 4 do:
				[:j | (q at: j) = c ifTrue:
					[q at: j put: (rm corners at: i)]]]].
	warp _ (WarpBlt toForm: Display)
		clipRect: (nineRects first topLeft corner: nineRects last bottomRight);
		sourceForm: Display;
		combinationRule: Form over.
	[Sensor anyButtonPressed] whileFalse:
		[cp _ Sensor cursorPoint-(s asPoint*3//2).
		cursorQuads _ nineQuads collect:
			[:q | q collect: [:p | p translateBy: cp]].
		cursorQuads with: nineRects do:
			[:q :r | warp copyQuad: q toRect: r]]