composeForm
	"For the TT strings in MVC widgets in a Morphic world such as a progress bar, the form is created by Morphic machinery."
	| canvas tmpText |
	Smalltalk isMorphic
		ifTrue:
			[tmpText _ TextMorph new contentsAsIs: text deepCopy.
			foreColor ifNotNil: [tmpText text addAttribute: (TextColor color: foreColor)].
			backColor ifNotNil: [tmpText backgroundColor: backColor].
			tmpText setTextStyle: textStyle.
			canvas _ FormCanvas on: (Form extent: tmpText extent depth: 32).
			tmpText drawOn: canvas.
			form _ canvas form.
		]
		ifFalse: [form _ self asParagraph asForm]