generateScriptTemplateWithCurrentPackages
	"ScriptLoader new generateScriptTemplateWithCurrentPackages"
	
	| str withoutScriptLoader |
	str := ReadWriteStream on: (String new: 1000).
	str nextPutAll: 'scriptXXX' ; cr ; cr ; tab.
	str nextPutAll: '| names|'; cr.
	str nextPutAll: 'names := '.
	str nextPut: $'.
	withoutScriptLoader := self currentVersions reject: [:each| ('*ScriptLoader*' match: each)].
	withoutScriptLoader 
		do: [ :each |
			str nextPutAll: each ; nextPutAll: '.mcz']
		separatedBy: [str nextPut: Character cr].
	str nextPut: $'; nextPut: Character cr.
	str nextPutAll: 'findTokens: '' '', String cr.

	self loadTogether: names merge: false.'.
	^ str contents