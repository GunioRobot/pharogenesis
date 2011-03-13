fromStringArray: array
	| class |
	class _ nil.
	array first = 'requestpackages' ifTrue: [ class _ UMRequestPackages ].
	array first = 'packages' ifTrue: [ class _ UMPackageList ].
	array first = 'error' ifTrue: [ class _ UMError ].
	array first = 'addaccount' ifTrue: [ class _ UMAddAccount ].
	array first = 'addpackage' ifTrue: [ class _ UMAddPackage ].
	array first = 'editaccount' ifTrue: [ class _ UMEditAccount ].
	array first = 'editedaccount' ifTrue: [ class _ UMEditedAccount ].
	array first = 'packageadded' ifTrue: [ class _ UMPackageAdded ].
	array first = 'packageremoved' ifTrue: [ class _ UMPackageRemoved ].
	array first = 'removepackage' ifTrue: [ class _ UMRemovePackage ].
	array first = 'selectserver' ifTrue: [ class _ UMSelectServer ].
	array first = 'protocolversion' ifTrue: [ class _ UMProtocolVersion ].

	class ifNil: [
			^UMMalformed fromStringArray: array ].
	
	^[ class fromStringArray: array ] on: Error do: [ :ex | UMMalformed fromStringArray: array ]