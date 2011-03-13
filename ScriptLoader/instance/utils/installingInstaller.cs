installingInstaller
	"self new installingInstaller"
	
	| mc  files fileToLoad version |
	mc := Smalltalk at: #MCHttpRepository ifPresent: [:repoClass | repoClass location: 'www.squeaksource.com/Installer' user: 'squeak' password: 'squeak'].
	files := mc readableFileNames asSortedCollection: [:a :b | [(a findBetweenSubStrs: #($.)) allButLast last asInteger > (b findBetweenSubStrs: #($.)) allButLast last asInteger] on: Error do: [:ex | false]].
	fileToLoad := files detect: [ :aFile | aFile beginsWith: 'Installer-Core' ] ifNone: [ nil ].
	version := mc versionFromFileNamed: fileToLoad.
	version workingCopy repositoryGroup addRepository: mc.
	mc creationTemplate: mc asCreationTemplate.
	version load.
	
	^ (Smalltalk at: #Installer)