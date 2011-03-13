newPackage
	| editor |
	self acceptFields.

	editor _ UPackageEditor package: self createNewPackage whenComplete: [ :p |
		self acceptFields.
		self sendMessage: (UMAddPackage username: username password: password package: p) ].
	editor openInMorphic.
	packageEditors add: editor.
