formatterFor: formatterName
	"get the formatter for the given name.
uses lazy initialization.  Could eventually check whether the on-disk file
has been updated."
	| fileName fileModTime |
	
	"first,
create the dictionary of formatters if it isn't already"
	formatters
== nil ifTrue: [
		formatters _ Dictionary new. ].


	"get the filename for the template source"
	fileName _
formatterName, '.html'.

	"get its modification time"
	fileModTime
_ ((FileDirectory on: ServerAction serverDirectory, source) entryAt:
fileName) at: 3.

	"create the formatter if necessary"

	((formatters includesKey: formatterName) not or: [

	((formatters at: formatterName) at: 2) < fileModTime ])

	ifTrue: [
		Transcript show: '(recompiling formatter ',
formatterName, ')'; cr.
		formatters at: formatterName put:
(Array with:
			(HTMLformatter forEvaluatingEmbedded: (self
fileContents: (source, formatterName, '.html')))

	with: fileModTime)
	].

	"return the formatter"

	^(formatters at: formatterName) at: 1