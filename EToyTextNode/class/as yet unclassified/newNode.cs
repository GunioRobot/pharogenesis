newNode

	^self new contents: (
		Text
			string: 'new item'
			attribute: (TextFontChange fontNumber: 2)
	)