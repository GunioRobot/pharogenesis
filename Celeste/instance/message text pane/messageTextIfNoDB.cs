messageTextIfNoDB
	"return text to display to the user if there is no DB opened"
	| openCommand |
	openCommand := 'OPEN' asText.
	openCommand addAttribute: (PluggableTextAttribute evalBlock: [ self openDefaultDatabase ]).
	openCommand addAttribute: (TextColor blue).


	^'No DB is currently open.  Press ' asText, openCommand, ' to open the default database.'