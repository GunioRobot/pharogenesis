openLabel: aString andTerminate: terminateBoolean
	"Create a standard system view of the model, me, a StringHolder and open it.; do not terminate the active process if in mvc"
	| topView codeView |

	Smalltalk isMorphic ifTrue: [^ self openAsMorphLabel: aString].

	topView _ (StandardSystemView new) model: self.
	topView borderWidth: 1.
	topView label: aString.
	topView minimumSize: 100 @ 50.

	codeView _ PluggableTextView on: self 
			text: #contents accept: #acceptContents:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	codeView window: (0@0 extent: 200@200).
	topView addSubView: codeView.
	"self contents size > 0 ifTrue: [
			codeView hasUnacceptedEdits: true].  Is it already saved or not??"
	terminateBoolean
		ifTrue:
			[topView controller open]
		ifFalse:
			[topView controller openNoTerminate]