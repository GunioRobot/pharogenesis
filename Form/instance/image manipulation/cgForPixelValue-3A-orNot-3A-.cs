cgForPixelValue: pv orNot: not
	"Return the center of gravity for all pixels of value pv.
	Note:  If orNot is true, then produce the center of gravity for all pixels
	that are DIFFERENT from the supplied (background) value"
	| pixCount weighted xAndY |
	xAndY _ (Array with: (self xTallyPixelValue: pv orNot: not)
					with: (self yTallyPixelValue: pv orNot: not)) collect:
		[:profile |	"For both x and y profiles..."
		pixCount _ 0.  weighted _ 0.
		profile doWithIndex:
			[:t :i | pixCount _ pixCount + t.
			weighted _ weighted + (t*i)].
		pixCount = 0  "Produce average of nPixels weighted by coordinate"
			ifTrue: [0.0]
			ifFalse: [weighted asFloat / pixCount asFloat - 1.0]].

	^ xAndY first @ xAndY last
"
| f cg |
[Sensor anyButtonPressed] whileFalse:
	[f _ Form fromDisplay: (Sensor cursorPoint extent: 50@50).
	cg _ f cgForPixelValue: (Color black pixelValueForDepth: f depth) orNot: false.
	f displayAt: 0@0.
	Display fill: (cg extent: 2@2) fillColor: Color red].
	ScheduledControllers restore
"