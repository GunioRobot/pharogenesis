install
	"Install using DVS."

	| imagePackageLoader streamPackageLoader packageInfo packageManager baseName current new manager |
	self cache; unpack.
	imagePackageLoader _ Smalltalk at: #ImagePackageLoader ifAbsent: [].
	streamPackageLoader _ Smalltalk at: #StreamPackageLoader ifAbsent: [].
	packageInfo _ Smalltalk at: #PackageInfo ifAbsent: [].
	packageManager _ Smalltalk at: #FilePackageManager ifAbsent: [].

	({ imagePackageLoader. streamPackageLoader. packageInfo. packageManager } includes: nil)
		ifTrue: [ (self confirm: ('DVS support is not loaded, but would be helpful in loading ', unpackedFileName, '.
It isn''t necessary, but if you intend to use DVS later it would be a good idea to load it now.
Load it from SqueakMap?'))
			ifTrue: [ self class loadDVS. ^self install ]
			ifFalse: [ ^self fileIn ]].

	baseName _ packageRelease name.
	dir rename: unpackedFileName toBe: (baseName, '.st').
	unpackedFileName _ baseName, '.st'.

	(manager _ packageManager allManagers detect: [ :pm | pm packageName = baseName ] ifNone: [])
		ifNotNil: [
			current _ imagePackageLoader new package: (packageInfo named: baseName).
			new _ streamPackageLoader new stream: (dir readOnlyFileNamed: unpackedFileName).
			(new changesFromBase: current) fileIn ]
		ifNil: [
			self fileIn.
			manager _ packageManager named: baseName. ].

	manager directory: dir.
	packageManager changed: #allManagers.
	packageRelease noteInstalled