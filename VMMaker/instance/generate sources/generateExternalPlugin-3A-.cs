generateExternalPlugin: pluginName 
	"generate the named external plugin"
	| exports plugin |

	"Refuse to translate this plugin if it requires platform specific files and they are not present."
	[plugin _ self validateExternalPlugin: pluginName] on: VMMakerException do:[^self].

	exports _ plugin
				translateInDirectory: (self externalPluginsDirectoryFor: plugin)
				doInlining: inline.
	logger show: 'external plugin ' , plugin name , ' generated as ' , plugin moduleName; cr.
	exports ifNotNil: ["if exp is nil we skip this since the plugin was already up to date"
			self export: exports forExternalPlugin: plugin].
	self processFilesForExternalPlugin: plugin