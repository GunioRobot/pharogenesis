getLines
	"private - answer a collection of lines with the server response"
	| url answer string lines |
	url := self urlFromServer: self server directories: {'programmatic'} , self directories.
	url := url , self slash.
	""
	Cursor read
		showWhile: [""
			answer := HTTPClient httpGetDocument: url.
			string := answer contents.
			(string beginsWith: '--OK--')
				ifFalse: [^ nil]].
	""
	lines := OrderedCollection new.
	(string allButFirst: 6)
		linesDo: [:line | lines add: line squeakToIso].
	""
	^ lines