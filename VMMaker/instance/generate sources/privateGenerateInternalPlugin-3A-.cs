privateGenerateInternalPlugin: pluginName 
	"generate the named internal plugin"
	| plugin |
	"Refuse translate this plugin if it requires platform specific files and  
	they are not present."
	plugin _ self validateInternalPlugin: pluginName.

	plugin
		ifNil: [^ self couldNotFindPluginClass: pluginName].
	plugin
		translateInDirectory: (self internalPluginsDirectoryFor: plugin)
		doInlining: inline.
	logger show: 'internal plugin ' , plugin name , ' generated as ' , plugin moduleName; cr.
	self processFilesForInternalPlugin: plugin.
