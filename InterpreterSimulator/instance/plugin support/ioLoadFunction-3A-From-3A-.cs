ioLoadFunction: functionString From: pluginString
	"Load and return the requested function from a module"
	| plugin fnSymbol |
	fnSymbol _ functionString asSymbol.
	Transcript cr; show:'Looking for ', functionString, ' in '.
	pluginString isEmpty
		ifTrue:[Transcript show: 'vm']
		ifFalse:[Transcript show: pluginString].
	plugin _ pluginList 
				detect:[:any| any key = pluginString asString]
				ifNone:[self loadNewPlugin: pluginString].
	plugin ifNil:[
		"Transcript cr; show:'Failed ... no plugin found'." ^ 0].
	plugin _ plugin value.
	mappedPluginEntries doWithIndex:[:pluginAndName :index|
		((pluginAndName at: 1) == plugin 
			and:[(pluginAndName at: 2) == fnSymbol]) ifTrue:[
				"Transcript show:' ... okay'." ^ index]].
	(plugin respondsTo: fnSymbol) ifFalse:[
		"Transcript cr; show:'Failed ... primitive not in plugin'." ^ 0].
	mappedPluginEntries _ mappedPluginEntries copyWith: (Array with: plugin with: fnSymbol).
	"Transcript show:' ... okay'."
	^ mappedPluginEntries size