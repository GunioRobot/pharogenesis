defaultAnnotationPaneHeight
	"Answer the receiver's preferred default height for new annotation panes."

	^ Preferences parameterAt: #defaultAnnotationPaneHeight default: [25]