fileInPackageNamed: memberName 
	"This is to be used from preamble/postscript code to file in zip 
	members as DVS packages."
	| member current new baseName imagePackageLoader packageInfo streamPackageLoader packageManager |
	member _ self zip memberNamed: memberName.
	member ifNil: [ ^self errorNoSuchMember: memberName ].

	imagePackageLoader _ Smalltalk at: #ImagePackageLoader ifAbsent: [].
	streamPackageLoader _ Smalltalk at: #StreamPackageLoader ifAbsent: [].
	packageInfo _ Smalltalk at: #PackageInfo ifAbsent: [].
	packageManager _ Smalltalk at: #FilePackageManager ifAbsent: [].

	"If DVS isn't present, do a simple file-in"
	(packageInfo isNil or: [imagePackageLoader isNil or: [streamPackageLoader isNil]])
		ifTrue: [ ^ self fileInMemberNamed: memberName ].

	baseName _ memberName copyReplaceAll: '.st' with: '' asTokens: false.
	(packageManager allManagers anySatisfy: [ :pm | pm packageName = baseName ])
		ifTrue: [
			current _ imagePackageLoader new package: (packageInfo named: baseName).
			new _ streamPackageLoader new stream: member contentStream ascii.
			(new changesFromBase: current) fileIn ]
		ifFalse: [ self class fileIntoChangeSetNamed: baseName fromStream: member contentStream ascii setConverterForCode. ].

	packageManager registerPackage: baseName.

	self installed: member.