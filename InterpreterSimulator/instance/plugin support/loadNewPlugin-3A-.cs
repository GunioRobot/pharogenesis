loadNewPlugin: pluginString
	| plugin simClass |
	Transcript cr; show:'Looking for module ', pluginString.
	plugin _ simClass _ nil.
	InterpreterPlugin allSubclassesDo:[:plg|
		plg moduleName asString = pluginString asString ifTrue:[
			simClass _ plg simulatorClass.
			plugin ifNil:[plugin _ simClass]
				ifNotNil:[plugin == simClass ifFalse:[^self error:'This won''t work...']].
		].
	].
	plugin ifNil:[Transcript show: ' ... not found'. ^nil].
	plugin _ plugin new.
	plugin setInterpreter: self. "Ignore return value from setInterpreter"
	(plugin respondsTo: #initialiseModule) ifTrue:[
		plugin initialiseModule ifFalse:[Transcript show: ' ... initialiser failed'.^nil]. "module initialiser failed"
	].
	pluginList _ pluginList copyWith: (pluginString asString -> plugin).
	Transcript show:' ... loaded'.
	^pluginList last