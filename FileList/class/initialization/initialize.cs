initialize
	"FileList2 initialize"

	RecentDirs := OrderedCollection new.
	(self systemNavigation allClassesImplementing: #fileReaderServicesForFile:suffix:) do: 		[:providerMetaclass |
			self registerFileReader: providerMetaclass soleInstance]