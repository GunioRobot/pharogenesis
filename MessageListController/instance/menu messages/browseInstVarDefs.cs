browseInstVarDefs
	"Request a browser of methods that store to a chosen instance variable.
	7/30/96 sw: made this di feature for Browsers also available in Msg List browsers."

	| aClass |
	self controlTerminate.
	(aClass _ model selectedClassOrMetaClass) notNil ifTrue: 
		[aClass browseInstVarDefs].
	self controlInitialize