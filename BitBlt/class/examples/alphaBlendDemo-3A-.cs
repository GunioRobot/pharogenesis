alphaBlendDemo: sz  "Display restoreAfter: [BitBlt alphaBlendDemo: 30]"
	"Displays 10 different alphas, and then paints with a gradient brush"
	| f |  "Get out of painting with option-click"
	1 to: 10 do: [:i | Display fill: (50*i@10 extent: 50@50)
						rule: Form blend
						fillColor: (Color red alpha: i/10)].
	f _ Form extent: sz asPoint depth: 32.
	1 to: 5 do: 
		[:i | f fillShape: (Form dotOfSize: sz*(6-i)//5)
				fillColor: (Color red alpha: (i/5 raisedTo: 2))
				at: f extent // 2].
	[Sensor yellowButtonPressed] whileFalse:
		[Sensor redButtonPressed ifTrue:
			[(BitBlt toForm: Display) copyForm: f to: Sensor cursorPoint rule: Form blend]]