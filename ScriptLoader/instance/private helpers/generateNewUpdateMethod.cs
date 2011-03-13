generateNewUpdateMethod
	"ScriptLoader new compileNewUpdateMethod"
	
	| str mthName |
	str := ReadWriteStream on: (String new: 1000).
	mthName := 'updateFrom', (self getLatestUpdateNumber + 1) asString.
	str nextPutAll: mthName ; cr ; cr ; tab.
	str nextPutAll: '"self new ', mthName, '"' ; cr.
	
	str nextPutAll: '	self script' , self getLatestScriptNumber asString, '.'.
	str nextPutAll: '
	self flushCaches.
	'.
	
	^ str contents