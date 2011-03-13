noteInstalledPackageWithId: aPackageId autoVersion: aVersion name: aName
	"The package release was just successfully installed.
	Can be used to inform SM of an installation not been
	done using SM, even when the map isn't loaded.

	We record the fact in our Dictionary of installed packages
	and log a 'do it' to mark this in the changelog.
	The doit helps keeping track of the packages when
	recovering changes etc - not a perfect solution but should help.
	The map used is the default map.
	The id of the package is the key and the value is an OrderedCollection
	of Arrays with the release auto version, the point in time and the current installCounter."

	| time name id v |
	v := aVersion isString ifTrue: [aVersion asVersion] ifFalse: [aVersion].
	aName ifNil: [name := '<unknown package name>'] ifNotNil: [name := aName].
	id := UUID fromString: aPackageId.
	time := Time totalSeconds.
	self countInstall.
	self markInstalled: id version: v time: time counter: installCounter.
	(((Smalltalk classNamed: 'SmalltalkImage') ifNotNilDo: [:si | si current]) ifNil: [Smalltalk])
		logChange: '"Installed ', name, ' auto version ', v versionString, '".
(Smalltalk at: #SMSqueakMap ifAbsent: []) ifNotNil:[
	SMSqueakMap noteInstalledPackageWithId: ', id asString storeString, ' autoVersion: ', v storeString, ' atSeconds: ', time asString, ' number: ', installCounter asString, ']'