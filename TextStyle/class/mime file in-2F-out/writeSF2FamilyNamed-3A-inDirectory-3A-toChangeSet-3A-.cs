writeSF2FamilyNamed: familyName inDirectory: directoryName toChangeSet: csName 
	"
	TextStyle writeSF2FamilyNamed: 'Accuny' inDirectory: 'AccunyCorrectedFeb252004Beta Folder' toChangeSet: 'AccunyInstall'.
	"

	| oldDefaultDirectory family |
	oldDefaultDirectory := FileDirectory default.
	family := OrderedCollection new.
	FileDirectory 
		setDefaultDirectory: (FileDirectory default fullNameFor: directoryName).
	[family addAll: (StrikeFont readStrikeFont2Family: familyName) ] 
		ensure: [FileDirectory setDefaultDirectory: oldDefaultDirectory fullName].
	family do: [:f | f reset].
	self 
		writeStyle: (TextStyle fontArray: family asArray)
		named: familyName
		toChangeSet: csName