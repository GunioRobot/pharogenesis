toothpaste: diam		"Display restoreAfter: [Form toothpaste: 30]"
	"Draws wormlike lines by laying down images of spheres.
	See Ken Knowlton, Computer Graphics, vol. 15 no. 4 p352.
	Draw with mouse button down; terminate by option-click."
	| facade ball filter point queue port color q colors colr colr2 |
	colors _ Display depth = 1
		ifTrue: [Array with: Color black]
		ifFalse: [Color red wheel: 12].
	facade _ Form extent: diam@diam offset: (diam//-2) asPoint.
	(Form dotOfSize: diam) displayOn: facade
			at: (diam//2) asPoint clippingBox: facade boundingBox
			rule: Form under fillColor: Color white.
	#(1 2 3) do:
		[:x |  "simulate facade by circles of gray"
		(Form dotOfSize: x*diam//5) displayOn: facade
			at: (diam*2//5) asPoint clippingBox: facade boundingBox
			rule: Form under
			fillColor: (Color perform: 
					(#(black gray lightGray) at: x)).
		"facade displayAt: 50*x@50"].
	ball _ Form dotOfSize: diam.
	color _ 8.
	[ true ] whileTrue:
		[port _ BitBlt current toForm: Display.
		"Expand 1-bit forms to any pixel depth"
		port colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
		queue _ OrderedCollection new: 32.
		16 timesRepeat: [queue addLast: -20@-20].
		Sensor waitButton.
		Sensor yellowButtonPressed ifTrue: [^ self].
		filter _ Sensor cursorPoint.
		colr _ colors atWrap: (color _ color + 5).  "choose increment relatively prime to colors size"
		colr2 _ colr alphaMixed: 0.3 with: Color white.
		[Sensor redButtonPressed or: [queue size > 0]] whileTrue:
			[filter _ filter * 4 + Sensor cursorPoint // 5.
			point _ Sensor redButtonPressed
				ifTrue: [filter] ifFalse: [-20@-20].
			port copyForm: ball to: point rule: Form paint fillColor: colr.
			(q _ queue removeFirst) == nil ifTrue: [^ self].	"exit"
			Display depth = 1
				ifTrue: [port copyForm: facade to: q rule: Form erase]
				ifFalse: [port copyForm: facade to: q rule: Form paint fillColor: colr2].
			Sensor redButtonPressed ifTrue: [queue addLast: point]]].
