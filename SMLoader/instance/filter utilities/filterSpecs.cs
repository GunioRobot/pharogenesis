filterSpecs
	"Return a specification for the filter menu. Is called each time."

	| specs |
	specs := #(
	#('display only auto-installable packages' #filterAutoInstall 'display only packages that can be installed automatically')
	#('display only new available packages' #filterAvailable 'display only packages that are not installed or that have newer releases available.')
	#('display only new safely available packages' #filterSafelyAvailable 'display only packages that are not installed or that have newer releases available that are safe to install, meaning that they are published and meant for the current version of Squeak.')
	#('display only installed packages' #filterInstalled 'display only packages that are installed.')
	#('display only published packages' #filterPublished 'display only packages that have at least one published release.'))
		asOrderedCollection.
	categoriesToFilterIds do: [:catId |
		specs add: {'display only packages in ', (model object: catId) name. catId. 'display only packages that are in the category.'}].
	^ specs