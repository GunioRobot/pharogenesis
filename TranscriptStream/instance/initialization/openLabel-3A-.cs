openLabel: aString 
	"Open a window on this transcriptStream"

	| topView codeView |
	Smalltalk isMorphic ifTrue: [^ (self openAsMorphLabel: aString) openInWorld].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
	topView label: aString.
	topView minimumSize: 100 @ 50.

	codeView _ PluggableTextView on: self text: nil accept: nil
					readSelection: nil menu: #codePaneMenu:shifted:.
	codeView window: (0@0 extent: 200@200).
	topView addSubView: codeView.
	topView controller open