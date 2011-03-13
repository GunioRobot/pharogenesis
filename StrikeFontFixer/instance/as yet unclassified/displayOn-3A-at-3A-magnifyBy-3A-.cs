displayOn: aDisplayObject at: aPoint magnifyBy: aNumber

	| form hStep vStep bb source nextPoint |
	hStep _ (strikeFont maxWidth * aNumber * 1.2) asInteger.
	vStep _ (strikeFont height * aNumber *  1.2) asInteger.
	
	form _ Form extent: (hStep * 16)@(vStep * 16).
	bb _ BitBlt toForm: form.
	0 to: 15 do: [:i |
		1 to: 16 do: [:j |
			source _ ((charForms at: (i * 16 + j)) magnifyBy: aNumber).
			nextPoint _ (hStep * (j - 1)@(vStep * i)).
			bb copy: ((nextPoint+((hStep@vStep - source extent) // 2)) extent: source extent)
				from: 0@0 in: source fillColor: Color black rule: Form over.
		].
	].
	form displayOn: aDisplayObject at: aPoint.
