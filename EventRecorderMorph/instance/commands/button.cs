button
	"Make a simple button interface for replay only"
	| butnCaption erm |
	butnCaption _ FillInTheBlank request: 'Caption for this butn?' initialAnswer: 'play'.
	butnCaption isEmpty ifTrue: [^ self].
	erm _ (EventRecorderMorph basicNew
				caption: butnCaption
				voiceRecorder: voiceRecorder copy
				tape: tape) initialize.
	self world primaryHand attachMorph: erm