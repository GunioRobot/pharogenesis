install
	"Install using DVS."

	| imagePackageLoader streamPackageLoader packageInfo packageManager baseName current new manager |
	self cache; unpack.
	imagePackageLoader := Smalltalk at: #ImagePackageLoader ifAbsent: [].
	streamPackageLoader := Smalltalk at: #StreamPackageLoader ifAbsent: [].
	packageInfo := Smalltalk at: #PackageInfo ifAbsent: [].
	packageManager := Smalltalk at: #FilePackageManager ifAbsent: [].

	({ imagePackageLoader. streamPackageLoader. packageInfo. packageManager } includes: nil)
		ifTrue: [ (self confirm: ('DVS support is not loaded, but would be helpful in loading ', unpackedFileName, '.
It isn''t necessary, but if you intend to use DVS later it would be a good idea to load it now.
Load it from SqueakMap?'))
			ifTrue: [ self class loadDVS. ^self install ]
			ifFalse: [ ^self fileIn ]].

	baseName := packageRelease name.
	dir rename: unpackedFileName toBe: (baseName, '.st').
	unpackedFileName := baseName, '.st'.

	(manager := packageManager allManagers detect: [ :pm | pm packageName = baseName ] ifNone: [])
		ifNotNil: [
			current := imagePackageLoader new package: (packageInfo named: baseName).
			new := streamPackageLoader new stream: (dir readOnlyFileNamed: unpackedFileName).
			(new changesFromBase: current) fileIn ]
		ifNil: [
			self fileIn.
			manager := packageManager named: baseName. ].

	manager directory: dir.
	packageManager changed: #allManagers.
	packageRelease noteInstalled