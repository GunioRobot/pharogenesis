addTextInputToFormatter: formatter
	"is it a submit button?"
	| inputMorph size |
	inputMorph _ PluggableTextMorph on: StringHolder new text: #contents accept: #acceptContents:.
	self type = 'password'
		ifTrue: [inputMorph font: (StrikeFont passwordFontSize: 12)].
	size _ (self getAttribute: 'size' default: '12') asNumber.
	inputMorph extent: (size*10@20).
	formatter addMorph: inputMorph.
	formatter currentFormData addInput:
		(TextInput name: self name defaultValue: self defaultValue  textMorph: inputMorph).