generateExternalPlugins
	"generate the external plugins"

	self deleteUnwantedExternalPluginDirectories.
	self externalPluginsDo: [:plugin | 
		self generateExternalPlugin: plugin].
	self storeExternalPluginList.