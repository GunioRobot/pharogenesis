noteInstalledPackageWithId: uuidString autoVersion: version atSeconds: sec number: num
	"We are replaying a change that indicates that a package release
	was just installed using SM2. If there is a map we let it record this,
	otherwise we ask the user if we should create/recreate the map."

	DefaultMap
		ifNotNil: [DefaultMap noteInstalledPackageWithId: uuidString autoVersion: version
					atSeconds: sec number: num]
		ifNil: [
			self askUser
				ifTrue:[self default noteInstalledPackageWithId: uuidString autoVersion: version
							atSeconds: sec number: num]]