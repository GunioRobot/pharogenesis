loadEToyFromDisk
	"EToySystem loadEToyFromDisk"

	| aName aFileStream aHolder |
	aName _ Utilities chooseFileWithSuffix: '.sqo'.
	aName size == 0 ifTrue: [^ self].
	aFileStream _ FileStream oldFileNamed: aName.
	aHolder _ aFileStream fileInObjectAndCode.	"code filed in is the Model class"
	aHolder title: aName sansPeriodSuffix.
	EToyPlayer openFromSaveFileOn: aHolder