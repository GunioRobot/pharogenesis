platformsListMenu
	"create a menu of all known platforms"
	|choice  platnames|
	platnames _ vmMaker platformRootDirectory directoryNames copyWithoutAll: #('Cross' 'CVS').
	choice  _ (PopUpMenu labelArray: platnames lines: #()) startUp.
	choice = 0 ifTrue:[^self].
	self platformNameText: (platnames at: choice) asText