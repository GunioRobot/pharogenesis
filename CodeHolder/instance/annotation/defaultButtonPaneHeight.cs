defaultButtonPaneHeight
	"Answer the user's preferred default height for new button panes."

	^ Preferences parameterAt: #defaultButtonPaneHeight default: [25]