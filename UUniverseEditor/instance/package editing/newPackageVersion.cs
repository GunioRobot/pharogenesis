newPackageVersion
	| package editor newPackage |
	self anyPackageSelected ifFalse: [ ^self ].
	self acceptFields.
	package _ self selectedPackage.
	
	newPackage _ package deepCopy.
	newPackage version: (UVersion readFromString: (newPackage version asString, 'new')).

	editor _ UPackageEditor package: newPackage whenComplete: [ :p |
		self acceptFields.
		self sendMessage: (UMAddPackage username: username password: password package: p) ].

	editor openInMorphic.
	packageEditors add: editor.
