computeLabelParagraph
	"Answer a Paragraph containing this menu's labels, one per line and centered."

	^ Paragraph withText: labelString asText style: (MenuStyle leftFlush)