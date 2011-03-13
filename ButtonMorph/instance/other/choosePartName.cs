choosePartName
	"Override to add null on-ticks script when this morph is named."

	| newName |
	newName _ super choosePartName.
	newName ifNil: [^ self].  "user cancelled or chose a bad part name"
	(self world model class)
		compile: self buttonUpSelector
		classified: 'scripts'
		notifying: nil.
