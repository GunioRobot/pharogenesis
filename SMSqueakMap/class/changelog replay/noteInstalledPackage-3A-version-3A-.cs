noteInstalledPackage: uuidString version: version
	"We are replaying a change that indicates that a package
	was just installed. If there is a map we let it record this,
	otherwise we ask the user if we should create/recreate the map."

	| choice |
	DefaultMap
		ifNotNil: [DefaultMap noteInstalledPackage: uuidString version: version]
		ifNil: [
			[choice := UIManager default chooseFrom: #('Yes' 'No' 'More info')
				title:
'There is no SqueakMap in this image,
do you wish to create/recreate it? (typical answer is Yes)' .
			choice = 3] whileTrue: [self inform:
'When packages are installed using SqueakMap a little mark is made
in the change log. When an image is reconstructed from the changelog
these marks are intended to keep your map informed about what packages
are installed. You probably already have a map on disk which will automatically be
reloaded if you choose ''Yes'', otherwise an new empty map will be created.
If you choose ''No'', it will only result in that SqueakMap will not know that this package
is installed in your image.
If you are still unsure - answer ''Yes'' since that is probably the best.'].
			choice = 1
				ifTrue:[self default noteInstalledPackage: uuidString version: version]]