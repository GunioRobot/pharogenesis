balloonText
	"Answer balloon help text or nil, if no help is available.
	NB: subclasses may override such that they programatically construct
	the text, for economy's sake, such as model phrases in a Viewer"

	| text |
	extension == nil ifTrue: [^ nil].
	(text _ extension balloonText) ifNotNil: [^ text].
	(text _ extension balloonTextSelector)
		ifNotNil: [^ (ScriptingSystem helpStringFor: text)
			withNoLineLongerThan: Preferences maxBalloonHelpLineLength].
	^ nil