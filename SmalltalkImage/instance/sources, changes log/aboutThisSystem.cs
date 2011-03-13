aboutThisSystem
	"Identify software version"
	| text dialog width |
	text := SmalltalkImage current systemInformationString withCRs.
	width := 0.
	text linesDo: [:l | width := width	max: (UITheme current textFont widthOfStringOrText: l)].
	dialog := LongMessageDialogWindow new entryText: text.
	dialog open.
	dialog width: (width + 120 min: Display width - 50)