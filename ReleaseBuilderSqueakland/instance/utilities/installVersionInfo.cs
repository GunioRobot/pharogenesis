installVersionInfo
	"ReleaseBuilderSqueakland new installVersionInfo"

	| highestUpdate newVersion |
	highestUpdate _ SystemVersion current highestUpdate.
	(self confirm: 'Reset highest update (' , highestUpdate printString , ')?')
		ifTrue: [SystemVersion current highestUpdate: 0].

	newVersion _ FillInTheBlank request: 'New version designation:' initialAnswer: 'Squeakland 3.8.' , highestUpdate printString. 
	SystemVersion newVersion: newVersion.
	(self confirm: self version , '
Is this the correct version designation?
If not, choose no, and fix it.') ifFalse: [^ self].
