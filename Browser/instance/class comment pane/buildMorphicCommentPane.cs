buildMorphicCommentPane
	"Construct the pane that shows the class comment.
	Respect the Preference for standardCodeFont."

	| commentPane |
	commentPane := BrowserCommentTextMorph
				on: self
				text: #classCommentText
				accept: #classComment:notifying:
				readSelection: nil
				menu: #codePaneMenu:shifted:.
	commentPane font: Preferences standardCodeFont.
	^ commentPane