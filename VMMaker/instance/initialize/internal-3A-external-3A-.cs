internal: arrayOfInternalPluginNames external: arrayOfExternalPluginNames
	"try to set up with the listed internal and external plugins. Check that they are supportable plugins, reject those that are not - remember that this depends on the platform etc "

	"since we went to some trouble to drop plugins we cannot handle, don't add them now"
	internalPlugins _ (self availablePlugins intersection: arrayOfInternalPluginNames) select: [:pl | self canSupportPlugin: pl].
	allPlugins _ allPlugins copyWithoutAll: internalPlugins.
	externalPlugins _ (allPlugins intersection: arrayOfExternalPluginNames) select: [:pl | self canSupportPlugin: pl ].
	allPlugins _ allPlugins copyWithoutAll: externalPlugins.
	