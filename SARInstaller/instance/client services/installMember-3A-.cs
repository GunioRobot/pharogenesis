installMember: memberOrName
	| memberName extension isGraphic stream member |
	member _ self memberNamed: memberOrName.
	member ifNil: [ ^false ].
	memberName _ member fileName.
	extension _ (FileDirectory extensionFor: memberName) asLowercase.
	Smalltalk at: #CRDictionary ifPresent: [ :crDictionary |
		(extension = crDictionary fileNameSuffix) ifTrue: [  self fileInGenieDictionaryNamed: memberName. ^true ] ].
	extension caseOf: {
		[ Project projectExtension ] -> [ self fileInProjectNamed: memberName createView: true ].
		[ FileStream st ] -> [ self fileInPackageNamed: memberName ].
		[ FileStream cs ] -> [  self fileInMemberNamed: memberName  ].
"		[ FileStream multiSt ] -> [  self fileInMemberNamedAsUTF8: memberName  ].
		[ FileStream multiCs ] -> [  self fileInMemberNamedAsUTF8: memberName  ].
"
		[ 'mc' ] -> [ self fileInMonticelloPackageNamed: memberName ].
		[ 'mcv' ] -> [ self fileInMonticelloVersionNamed: memberName ].
		[ 'mcz' ] -> [ self fileInMonticelloZipVersionNamed: memberName ].
		[ 'morph' ] -> [ self fileInMorphsNamed: member addToWorld: true ].
		[ 'ttf' ] -> [ self fileInTrueTypeFontNamed: memberName ].
		[ 'translation' ] -> [  self fileInMemberNamed: memberName  ].
	} otherwise: [
		('t*xt' match: extension) ifTrue: [ self openTextFile: memberName ]
			ifFalse: [ stream _ member contentStream.
		isGraphic _ ImageReadWriter understandsImageFormat: stream.
		stream reset.
		isGraphic
			ifTrue: [ self openGraphicsFile: member ]
			ifFalse: [ "now what?" ^false ]]
	].
	^true
