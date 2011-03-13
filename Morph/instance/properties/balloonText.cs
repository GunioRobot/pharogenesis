balloonText
	"NB: subclasses may override such that they programatically construct the text, for economy's sake, such as model phrases in a Viewer"
	| val |
	(val _ self valueOfProperty: #balloonText) ifNotNil: [^ val].
	(val _ self valueOfProperty: #balloonTextSelector) ifNotNil:
		[^ ScriptingSystem helpStringFor: val].
	^ nil