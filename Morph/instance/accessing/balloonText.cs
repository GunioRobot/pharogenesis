balloonText
	"Answer balloon help text or nil, if no help is available.  
	NB: subclasses may override such that they programatically  
	construct the text, for economy's sake, such as model phrases in 
	a Viewer"

	| text balloonSelector aString |
	extension ifNil: [^nil].
	(text := extension balloonText) ifNotNil: [^text].
	(balloonSelector := extension balloonTextSelector) ifNotNil: 
			[aString := ScriptingSystem helpStringOrNilFor: balloonSelector.
			((aString isNil and: [balloonSelector numArgs = 0]) 
				and: [self respondsTo: balloonSelector]) 
					ifTrue: [aString := self perform: balloonSelector]].
	^aString ifNotNil: 
			[aString asString 
				withNoLineLongerThan: Preferences maxBalloonHelpLineLength]