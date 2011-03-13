toothpaste: diam		"Display restoreAfter: [Form toothpaste: 30]"
	"Draws wormlike lines by laying down images of spheres.
	See Ken Knowlton, Computer Graphics, vol. 15 no. 4 p352.
	Draw with mouse button down; terminate by option-click."
	| facade ball filter point queue port color q colors |
	colors _ Display depth = 1
		ifTrue: [Array with: Color black]
		ifFalse: [Color red wheel: 20].
	facade _ Form extent: diam@diam offset: (diam//-2) asPoint.
	(Form dotOfSize: diam) displayOn: facade
			at: (diam//2) asPoint clippingBox: facade boundingBox
			rule: Form under fillColor: Color veryLightGray.
	#(1 2 3) do:
		[:x |  "simulate facade by circles of gray"
		(Form dotOfSize: x*diam//5) displayOn: facade
			at: (diam*2//5) asPoint clippingBox: facade boundingBox
			rule: Form under
			fillColor: (Color perform: 
					(#(black gray lightGray white veryLightGray) at: x))].
	ball _ Form dotOfSize: diam.
	color _ 1.
	[ true ] whileTrue:
		[port _ BitBlt toForm: Display.
		"Expand 1-bit forms to any pixel depth"
		port colorMap: (Bitmap with: 0 with: 16rFFFFFFFF).
		queue _ SharedQueue new: 32.
		16 timesRepeat: [queue nextPut: -20@-20].
		Sensor waitButton.
		Sensor yellowButtonPressed ifTrue: [^ self].
		filter _ Sensor cursorPoint.
		[Sensor redButtonPressed or: [queue size > 0]] whileTrue:
			[filter _ filter * 4 + Sensor cursorPoint // 5.
			point _ Sensor redButtonPressed
				ifTrue: [filter] ifFalse: [-20@-20].
			port copyForm: ball to: point rule: Form paint
					fillColor: (colors atWrap: color*9).
			(q _ queue next) == nil ifTrue: [^ self].	"exit"
			port copyForm: facade to: q rule: Form erase.
			Sensor redButtonPressed ifTrue: [queue nextPut: point]].
		color _ color + 1]