newTextEditorMorph
	"Answer a new morph for the text entry using a password font."
	
	|textEditor|
	textEditor := super newTextEditorMorph.
	textEditor font: (StrikeFont passwordFontSize: self theme textFont pointSize).
	^textEditor