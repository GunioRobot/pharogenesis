noteInstalledPackage: uuidString version: version atSeconds: sec number: num
	"We are replaying a change that indicates that a package
	was just installed. If there is a map we let it record this,
	otherwise we ask the user if we should create/recreate the map."

	DefaultMap
		ifNotNil: [DefaultMap noteInstalledPackage: uuidString version: version
					atSeconds: sec number: num]
		ifNil: [
			self askUser
				ifTrue:[self default noteInstalledPackage: uuidString version: version
							atSeconds: sec number: num]]