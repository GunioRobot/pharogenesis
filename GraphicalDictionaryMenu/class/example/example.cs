example
	"GraphicalDictionaryMenu example"
	| aDict |
	aDict _ Dictionary new.
	#('ColorTilesOff' 'ColorTilesOn' 'Controls') do:
		[:aString | aDict at: aString put: (ScriptingSystem formAtKey: aString)].
	self openOn: aDict withLabel: 'Testing One Two Three'