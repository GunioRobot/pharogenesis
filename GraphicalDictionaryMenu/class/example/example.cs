example
	"GraphicalDictionaryMenu example"
	| aDict |
	aDict _ Dictionary new.
	#('ColorTilesOff' 'ColorTilesOn' 'Controls') do:
		[:aString | aDict at: aString put: (ScriptingSystem formAtKey: aString)].
	aDict inspectFormsWithLabel: 'Testing One Two Three'