sillyButtons
	"A silly Apple GUI demo"

	^self doIt: '
		display dialog "The Mouse that Roars!" ',
			'buttons {"One", "Two", "Three"} default button "One"'
