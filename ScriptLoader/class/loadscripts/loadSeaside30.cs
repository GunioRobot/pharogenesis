loadSeaside30
	"self loadSeaside30"
	
	| instClass installer|
	self loadComanche.

	instClass := self environment at: #Installer ifAbsent: [self new installingInstaller].

	installer := 	instClass ss project: 'Seaside30'.
	installer	
		answer:  'Load Seaside.*' with: true;
		answer:  '.*SqueakSource User.*' with: '';
		answer:  '.*SqueakSource Password.*' with: '';
		answer:  'Run tests*' with: false;				
		install: 'LoadOrderTest'.
		
	"Set up to development environment (enables seaside web toolbar) "
	(self environment at: #WAAdmin) applicationDefaults 
		addParent: (self environment at: #WADevelopmentConfiguration) instance.
	
	(self environment at: #WASqueakServerAdaptorBrowser) open