installVersionInfo
	"self new installVersionInfo"

	| highestUpdate newVersion |
	highestUpdate := SystemVersion current highestUpdate.
	(self confirm: 'Reset highest update (' , highestUpdate printString , ')?')
		ifTrue: [SystemVersion current highestUpdate: 0].

	newVersion := FillInTheBlank request: 'New version designation:' initialAnswer: '3.9' , highestUpdate printString. 
	SystemVersion newVersion: newVersion.
	
