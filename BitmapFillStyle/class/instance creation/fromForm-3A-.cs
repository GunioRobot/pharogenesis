fromForm: aForm
	| fs |
	fs _ self form: aForm.
	fs direction: aForm width @ 0.
	fs normal: 0 @ aForm height.
	fs tileFlag: true.
	^fs