addFileInputToFormatter: formatter
	"is it a submit button?"
	| inputMorph size fileInput |
	inputMorph _ PluggableTextMorph on: StringHolder new text: #contents accept: #acceptContents:.
	size _ (self getAttribute: 'size' default: '12') asNumber.
	inputMorph extent: (size*10@20).
	fileInput _ FileInput name: self name textMorph: inputMorph.
	formatter addMorph: inputMorph;
		addMorph: ((PluggableButtonMorph on: fileInput getState: nil action: #browse)
				label: 'Browse').
	formatter currentFormData addInput: fileInput